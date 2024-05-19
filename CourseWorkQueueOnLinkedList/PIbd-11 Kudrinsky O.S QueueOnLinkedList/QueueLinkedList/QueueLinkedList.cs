using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;
using System;
using System.Collections.Generic;
using System.Collections;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList
{
    public class QueueLinkedList<T> : IEnumerable<T>
    {
        private LinkedList<T> list = new LinkedList<T>();
        private int maxSize;

        public QueueLinkedList() { }

        public QueueLinkedList(QueueParameters parameters)
        {
            maxSize = parameters.MaxSize;
        }

        public QueueLinkedList(IEnumerable<T> initialItems, QueueParameters parameters)
        {
            maxSize = parameters.MaxSize;
            foreach (var item in initialItems)
            {
                Enqueue(item);
            }
        }

        public void Enqueue(T item)
        {
            if (list.Count >= maxSize)
                throw new InvalidOperationException("Queue is full");

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public QueueState SaveState()
        {
            int[] stateArray = ToArray();
            return new QueueState(stateArray);
        }

        public void RestoreState(QueueState state)
        {
            list.Clear();
            foreach (var item in state.Array)
            {
                list.AddLast((T)Convert.ChangeType(item, typeof(T)));
            }
        }
    }
}
