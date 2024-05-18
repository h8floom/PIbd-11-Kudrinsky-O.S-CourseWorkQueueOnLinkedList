using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList;

public partial class MainForm : Form
{
    private QueueManager<int> queueManager;
    private QueueVisualizer queueVisualizer;
    private QueueStorage queueStorage;

    public MainForm()
    {
        InitializeComponent();
        queueManager = new QueueManager<int>(new QueueParameters(5), this); // Начальные параметры очереди
        queueVisualizer = new QueueVisualizer();
        queueStorage = new QueueStorage();
    }

    private void buttonAddElement_Click(object sender, EventArgs e)
    {
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


