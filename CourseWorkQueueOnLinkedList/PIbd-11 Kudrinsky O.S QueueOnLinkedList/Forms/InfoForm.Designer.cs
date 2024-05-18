namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            richTextBoxInfo = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(richTextBoxInfo);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 714);
            panel1.TabIndex = 1;
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxInfo.BackColor = SystemColors.Menu;
            richTextBoxInfo.Location = new Point(0, 3);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.Size = new Size(1192, 708);
            richTextBoxInfo.TabIndex = 0;
            richTextBoxInfo.Text = "";
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1222, 738);
            Controls.Add(panel1);
            Name = "InfoForm";
            Text = "Информация о программе";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private RichTextBox richTextBoxInfo;
    }
}