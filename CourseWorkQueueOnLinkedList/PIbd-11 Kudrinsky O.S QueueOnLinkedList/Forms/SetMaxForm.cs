namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;

public partial class SetMaxForm : Form
{
    public int MaxSize { get; private set; }

    public SetMaxForm()
    {
        InitializeComponent();
    }

    private void buttonSetMaxSize_Click(object sender, EventArgs e)
    {
        if (numericUpDownSize.Value > int.MaxValue)
        {
            MessageBox.Show("Введите корректный int", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else if (numericUpDownSize.Value > 0)
        {
            MaxSize = (int)numericUpDownSize.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Введите корректное положительное значение", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonSetMaxSizeReset_Click(object sender, EventArgs e)
    {
        numericUpDownSize.Value = 0;
    }

    private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
    {
        // Дополнительная логика, если необходимо
    }
}
