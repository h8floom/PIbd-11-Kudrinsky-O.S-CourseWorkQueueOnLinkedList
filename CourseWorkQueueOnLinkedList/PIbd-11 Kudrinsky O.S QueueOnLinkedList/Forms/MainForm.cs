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
        labelQueueSize.Text = ""; // Изначально метка пустая

        // Инициализируем queueManager при запуске формы
        InitializeQueueManager(1);
    }

    private void InitializeQueueManager(int maxSize, bool updateLabel = false)
    {
        // Если queueManager еще не создан, создаем новый
        if (queueManager == null)
        {
            queueManager = new QueueManager<int>(new QueueParameters(maxSize), this);
            queueVisualizer = new QueueVisualizer();
            queueStorage = new QueueStorage();
        }
        else
        {
            // Если queueManager уже создан, обновляем максимальный размер
            queueManager.UpdateMaxSize(maxSize);
        }

        // Обновляем текст метки, если требуется
        if (updateLabel)
        {
            labelQueueSize.Text = "Макс. размер очереди: " + maxSize.ToString();
        }
    }


private void buttonAddElement_Click(object sender, EventArgs e)
    {
        // Проверяем, был ли уже установлен максимальный размер
        if (!maxSizeSet)
        {
            // Если не был установлен, показываем сообщение с просьбой установить максимальный размер
            MessageBox.Show("Пожалуйста, установите максимальный размер очереди сначала.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Если максимальный размер уже был установлен, выполняем операцию добавления элемента
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
            if (queueManager != null)
            {
                queueManager.ClearStates();
                queueManager.storage.LoadFromFile(openFileDialog.FileName);
                queueManager.SetCurrentStateToLast();
                UpdateQueue();
                labelQueueSize.Text = ""; // Скрываем метку при загрузке файла
                maxSizeSet = false; // Сбрасываем флаг, чтобы указать, что максимальный размер не установлен
                MessageBox.Show("States loaded successfully!");
            }
            else
            {
                // Если queueManager не инициализирован, выведите сообщение об ошибке или выполните другие действия
                MessageBox.Show("Queue manager is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            InitializeQueueManager(maxSizeForm.MaxSize, true); // Инициализируем QueueManager с новым максимальным размером и обновляем текст метки
            maxSizeSet = true; // Устанавливаем флаг, что максимальный размер был установлен
        }
    }
}
