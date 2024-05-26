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
        if (numericUpDown.Value > int.MaxValue)
        {
            MessageBox.Show("Введите корректный int", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            int element = (int)numericUpDown.Value;
            AddClick?.Invoke(element);
            Close();
        }
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
        numericUpDown.Value = 0;
    }

    private void numericUpDown_ValueChanged(object sender, EventArgs e)
    {

    }
}

