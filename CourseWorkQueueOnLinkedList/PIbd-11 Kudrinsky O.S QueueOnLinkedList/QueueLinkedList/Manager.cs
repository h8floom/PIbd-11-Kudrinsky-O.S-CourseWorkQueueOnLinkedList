using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;

public class QueueManager<T>
{
    private QueueLinkedList<T> queue;
    public QueueStorage storage;
    private MainForm mainForm;

    public QueueManager(QueueParameters parameters, MainForm form)
    {
        queue = new QueueLinkedList<T>(parameters); // Передаем параметры в конструктор очереди
        storage = new QueueStorage();
        mainForm = form;
    }

    public void ExecuteOperation(string operation, T element = default)
    {
        if (operation == "Enqueue" && EqualityComparer<T>.Default.Equals(element, default(T)))
        {
            // Вызов формы для ввода данных
            AddElementForm addElementForm = new AddElementForm();
            addElementForm.AddClick += HandleEnqueueClicked; // Подключаем обработчик события
            addElementForm.Show();
        }
        else if (operation == "Dequeue")
        {
            if (queue.Count == 0)
            {
                MessageBox.Show("Queue is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Завершаем выполнение метода, чтобы избежать вызова queue.Dequeue()
            }
            queue.Dequeue();
            storage.AddState(queue.SaveState()); // Передача экземпляра queue
            mainForm.UpdateQueue();
        }
        else if (operation == "Enqueue" && !EqualityComparer<T>.Default.Equals(element, default(T)))
        {
            HandleEnqueueClicked((int)(object)element);
        }
    }

    public IEnumerable<QueueState> GetStates()
    {
        return storage.GetStates();
    }

    public void ClearStates()
    {
        storage.ClearStates();
    }

    public void SetCurrentStateToLast()
    {
        var lastState = storage.GetLastState();
        if (lastState != null)
        {
            queue.RestoreState(lastState); // Восстанавливаем состояние очереди из последнего сохраненного состояния
            mainForm.UpdateQueue();
        }
    }


    private void HandleEnqueueClicked(int element) // Обработчик события
    {
        try
        {
            queue.Enqueue((T)(object)element); // Приведение к типу T
            storage.AddState(queue.SaveState());
            mainForm.UpdateQueue();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public void UpdateMaxSize(int maxSize)
    {
        // Обновляем максимальный размер очереди
        queue.SetMaxSize(maxSize);
    }

}
