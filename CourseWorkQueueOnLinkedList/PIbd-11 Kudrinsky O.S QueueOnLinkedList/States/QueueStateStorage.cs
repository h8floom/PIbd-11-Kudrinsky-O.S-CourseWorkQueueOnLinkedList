using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList
{
    public class QueueStorage
    {
        private List<QueueState> states;
        private int currIndex = -1;

        public QueueStorage()
        {
            states = new List<QueueState>();
        }

        public void AddState(QueueState state)
        {
            states.Add(state);
            currIndex = states.Count - 1; // Обновляем текущий индекс на последний добавленный элемент
        }

        public IEnumerable<QueueState> GetStates()
        {
            return states;
        }

        public QueueState GetLastState()
        {
            return states.LastOrDefault();
        }

        public void ClearStates()
        {
            states.Clear();
            currIndex = -1; // Сбрасываем текущий индекс при очистке состояний
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var state in states)
                {
                    string line = string.Join(",", state.Array);
                    writer.WriteLine(line);
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            states.Clear();
            currIndex = -1; // Сбрасываем текущий индекс при загрузке состояний
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    try
                    {
                        int[] array = line.Split(',').Select(int.Parse).ToArray();
                        QueueState state = new QueueState(array);
                        states.Add(state);
                    }
                    catch (FormatException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                    }
                }
            }
            currIndex = states.Count - 1; // Устанавливаем текущий индекс на последний загруженный элемент
        }

        public QueueState? GetNextStep()
        {
            if (currIndex < states.Count - 1) // Проверяем, что есть следующее состояние
            {
                currIndex++;
                return states[currIndex];
            }
            return null; // Возвращаем null, если достигли последнего состояния
        }

        public QueueState? GetPreviousStep()
        {
            if (currIndex > 0) // Проверяем, что есть предыдущее состояние
            {
                currIndex--;
                return states[currIndex];
            }
            return null; // Возвращаем null, если достигли первого состояния или currIndex был равен -1
        }

        public bool HasNextStep()
        {
            return currIndex < states.Count - 1;
        }

        public bool HasPreviousStep()
        {
            return currIndex > 0;
        }
    }
}
