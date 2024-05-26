using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList
{
    public partial class MainForm : Form
    {
        private QueueManager<int> queueManager;
        private QueueVisualizer queueVisualizer;
        private QueueStorage queueStorage;
        private bool maxSizeSet = false;

        public MainForm()
        {
            InitializeComponent();
            labelQueueSize.Text = "";
            InitializeQueueManager(1);
            UpdateButtonStates();
        }

        private void InitializeQueueManager(int maxSize, bool updateLabel = false)
        {
            if (queueManager == null)
            {
                queueManager = new QueueManager<int>(new QueueParameters(maxSize), this);
                queueVisualizer = new QueueVisualizer();
                queueStorage = new QueueStorage();
            }
            else
            {
                queueManager.UpdateMaxSize(maxSize);
            }

            if (updateLabel)
            {
                labelQueueSize.Text = "Макс. размер очереди: " + maxSize.ToString();
            }

            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool isQueueCreated = queueManager != null && queueManager.GetStates().Any();
            bool hasPreviousStep = queueManager != null && queueManager.HasPreviousStep();
            bool hasNextStep = queueManager != null && queueManager.HasNextStep();
            bool hasMultipleElements = queueManager != null && queueManager.GetStates().Count() > 1;

            buttonAddElement.Enabled = maxSizeSet;
            buttonDeleteElement.Enabled = maxSizeSet;

            buttonAddElement.FlatStyle = maxSizeSet ? FlatStyle.Standard : FlatStyle.Flat;
            buttonDeleteElement.FlatStyle = maxSizeSet ? FlatStyle.Standard : FlatStyle.Flat;

            buttonAddElement.ForeColor = maxSizeSet ? SystemColors.ControlText : SystemColors.GrayText;
            buttonDeleteElement.ForeColor = maxSizeSet ? SystemColors.ControlText : SystemColors.GrayText;

            buttonBackStep.Enabled = isQueueCreated && hasPreviousStep && hasMultipleElements;
            buttonForwardStep.Enabled = isQueueCreated && hasNextStep;

            buttonBackStep.FlatStyle = buttonBackStep.Enabled ? FlatStyle.Standard : FlatStyle.Flat;
            buttonForwardStep.FlatStyle = buttonForwardStep.Enabled ? FlatStyle.Standard : FlatStyle.Flat;

            buttonBackStep.ForeColor = buttonBackStep.Enabled ? SystemColors.ControlText : SystemColors.GrayText;
            buttonForwardStep.ForeColor = buttonForwardStep.Enabled ? SystemColors.ControlText : SystemColors.GrayText;
        }

        private void buttonAddElement_Click(object sender, EventArgs e)
        {
            if (!maxSizeSet)
            {
                MessageBox.Show("Пожалуйста, установите максимальный размер очереди сначала.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            queueManager.ExecuteOperation("Enqueue");
            UpdateQueue();
        }

        private void buttonDeleteElement_Click(object sender, EventArgs e)
        {
            queueManager.ExecuteOperation("Dequeue");
            UpdateQueue();
        }

        public void UpdateQueue()
        {
            QueueState? currState = queueManager.GetStates().LastOrDefault();
            if (currState != null)
            {
                queueVisualizer.Visualize(currState, this);
            }
            UpdateButtonStates();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                queueManager.storage.SaveToFile(saveFileDialog.FileName);
                MessageBox.Show("Стадии сохранены успешно!");
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (queueManager != null)
                {
                    queueManager.ClearStates();
                    queueManager.storage.LoadFromFile(openFileDialog.FileName);
                    queueManager.SetCurrentStateToLast();
                    UpdateQueue();
                    labelQueueSize.Text = "";
                    maxSizeSet = false;
                    UpdateButtonStates();
                    MessageBox.Show("Стадии загружены успешно!");
                }
                else
                {
                    MessageBox.Show("Класс-управленец не инициализирован", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonInformation_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();
            infoForm.ShowDialog();
        }

        private void buttonSetMaxSize_Click(object sender, EventArgs e)
        {
            SetMaxForm maxSizeForm = new SetMaxForm();
            if (maxSizeForm.ShowDialog() == DialogResult.OK)
            {
                InitializeQueueManager(maxSizeForm.MaxSize, true);
                maxSizeSet = true;
                UpdateButtonStates();
            }
        }

        private void buttonForwardStep_Click(object sender, EventArgs e)
        {
            var nextStep = queueManager.GetNextStep();
            if (nextStep != null)
            {
                queueVisualizer.Visualize(nextStep, this);
            }
            UpdateButtonStates();
        }

        private void buttonBackStep_Click(object sender, EventArgs e)
        {
            var previousStep = queueManager.GetPreviousStep();
            if (previousStep != null)
            {
                queueVisualizer.Visualize(previousStep, this);
            }
            UpdateButtonStates();
        }
    }
}
