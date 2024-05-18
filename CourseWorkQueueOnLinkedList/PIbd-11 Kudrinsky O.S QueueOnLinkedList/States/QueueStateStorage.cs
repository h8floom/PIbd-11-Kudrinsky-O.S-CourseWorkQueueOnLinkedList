using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;
using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

public class QueueStorage
{
    private List<QueueState> states;

    public QueueStorage()
    {
        states = new List<QueueState>();
    }

    public void AddState(QueueState state)
    {
        states.Add(state);
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
    }
}
