using System.Xml.Linq;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;

public partial class AddElementForm : Form
{
    public event Action<int>? AddClick;

    public AddElementForm()
    {
        InitializeComponent();
    }

    private void buttonAddEl_Click(object sender, EventArgs e)
    {
        int number;
        if (int.TryParse(textBox.Text, out number))
        {
            AddClick?.Invoke(number);
            Close();
        }
        else
        {
            MessageBox.Show("Введите корректный int");
        }
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
        textBox.Text = string.Empty;
    }
}

