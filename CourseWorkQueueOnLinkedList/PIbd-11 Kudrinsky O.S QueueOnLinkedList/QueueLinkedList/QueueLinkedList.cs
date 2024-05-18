using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;

public class QueueLinkedList<T> : IEnumerable<T>
{
    private LinkedList<T> list = new LinkedList<T>();

    public void Enqueue(T item)
    {
        list.AddLast(item);
    }

    public T Dequeue()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T value = list.First.Value;
        list.RemoveFirst();
        return value;
    }

    public int Count => list.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int[] ToArray()
    {
        int[] result = new int[list.Count];
        int index = 0;
        foreach (var item in list)
        {
            result[index++] = Convert.ToInt32(item); // Преобразование элемента к типу int
        }
        return result;
    }

    public QueueState CreateMemento()
    {
        int[] stateArray = ToArray();
        return new QueueState(stateArray);
    }
}



