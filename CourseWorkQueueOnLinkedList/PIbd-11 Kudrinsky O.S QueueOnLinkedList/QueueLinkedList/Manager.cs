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
        queue = new QueueLinkedList<T>(parameters);
        storage = new QueueStorage();
        mainForm = form;
    }

    public void ExecuteOperation(string operation, T element = default)
    {
        if (operation == "Enqueue" && EqualityComparer<T>.Default.Equals(element, default(T)))
        {
            AddElementForm addElementForm = new AddElementForm();
            addElementForm.AddClick += HandleEnqueueClicked;
            addElementForm.Show();
        }
        else if (operation == "Dequeue")
        {
            if (queue.Count == 0)
            {
                MessageBox.Show("Очередь пустая!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            queue.Dequeue();
            storage.AddState(queue.SaveState()); // передача экземпляра queue
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
            queue.RestoreState(lastState); // восстановление ластового состояния
            mainForm.UpdateQueue();
        }
    }


    private void HandleEnqueueClicked(int element) // обработчик события
    {
        try
        {
            queue.Enqueue((T)(object)element);
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
        queue.SetMaxSize(maxSize);
    }

}
