using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList;

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
            UpdateButtonStates();
        }

        else
        {
            // Если queueManager уже создан, обновляем максимальный размер
            queueManager.UpdateMaxSize(maxSize);
        }

        if (updateLabel)
        {
            labelQueueSize.Text = "Макс. размер очереди: " + maxSize.ToString();
        }
    }


private void buttonAddElement_Click(object sender, EventArgs e)
    {
        if (!maxSizeSet)
        {
            MessageBox.Show("Пожалуйста, установите максимальный размер очереди сначала.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        queueManager.ExecuteOperation("Enqueue");
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
                MessageBox.Show("Стадии загружены успешно!");
            }
            else
            {
                MessageBox.Show("Класс-управленец не инициализирован", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    private void buttonSave_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            queueManager.storage.SaveToFile(saveFileDialog.FileName);
            MessageBox.Show("States saved successfully!");
        }
    }

    private void buttonInformation_Click(object sender, EventArgs e)
    {
        InfoForm infoform = new();
        infoform.ShowDialog();
    }

    private void buttonSetMaxSize_Click(object sender, EventArgs e)
    {
        SetMaxForm maxSizeForm = new SetMaxForm();
        if (maxSizeForm.ShowDialog() == DialogResult.OK)
        {
            InitializeQueueManager(maxSizeForm.MaxSize, true);
            maxSizeSet = true;
            UpdateButtonStates(); // Обновление состояния кнопок после установки размера очереди
        }
    }

    private void UpdateButtonStates()
    {
        // Установка состояния кнопок в зависимости от значения maxSizeSet
        buttonAddElement.Enabled = maxSizeSet;
        buttonDeleteElement.Enabled = maxSizeSet;

        // Установка стиля кнопок в зависимости от их состояния
        buttonAddElement.FlatStyle = maxSizeSet ? FlatStyle.Standard : FlatStyle.Flat;
        buttonDeleteElement.FlatStyle = maxSizeSet ? FlatStyle.Standard : FlatStyle.Flat;

        // Изменение цвета текста кнопок в зависимости от их состояния
        buttonAddElement.ForeColor = maxSizeSet ? SystemColors.ControlText : SystemColors.GrayText;
        buttonDeleteElement.ForeColor = maxSizeSet ? SystemColors.ControlText : SystemColors.GrayText;
    }
}
