using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList;

public partial class MainForm : Form
{
    private QueueManager<int> queueManager;
    private QueueVisualizer queueVisualizer;
    private QueueStorage queueStorage;
    private bool maxSizeSet = false; // Флаг, указывающий, был ли установлен максимальный размер

    public MainForm()
    {
        InitializeComponent();
    }

    // Метод для инициализации QueueManager
    private void InitializeQueueManager(int maxSize)
    {
        queueManager = new QueueManager<int>(new QueueParameters(maxSize), this); // Начальные параметры очереди
        queueVisualizer = new QueueVisualizer();
        queueStorage = new QueueStorage();
    }

    private void buttonAddElement_Click(object sender, EventArgs e)
    {
        // Проверяем, был ли уже установлен максимальный размер
        if (!maxSizeSet)
        {
            // Если не был установлен, показываем форму для установки максимального размера
            SetMaxForm maxSizeForm = new SetMaxForm();
            if (maxSizeForm.ShowDialog() == DialogResult.OK)
            {
                InitializeQueueManager(maxSizeForm.MaxSize); // Инициализируем QueueManager с установленным максимальным размером
                maxSizeSet = true; // Устанавливаем флаг, что максимальный размер был установлен
            }
        }
        else
        {
            // Если максимальный размер уже был установлен, выполняем операцию добавления элемента
            queueManager.ExecuteOperation("Enqueue");
        }
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
            MessageBox.Show("States saved successfully!");
        }
    }

    private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            queueManager.ClearStates();
            queueManager.storage.LoadFromFile(openFileDialog.FileName);
            queueManager.SetCurrentStateToLast();
            UpdateQueue();
            MessageBox.Show("States loaded successfully!");
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


}


