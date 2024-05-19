using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        if (int.TryParse(textBoxSetMaxSize.Text, out int maxSize) && maxSize > 0)
        {
            MaxSize = maxSize;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Please enter a valid positive integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonSetMaxSizeReset_Click(object sender, EventArgs e)
    {
        textBoxSetMaxSize.Text = string.Empty;
    }
}
