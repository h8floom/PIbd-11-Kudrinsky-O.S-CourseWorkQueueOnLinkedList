namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms
{
    partial class SetMaxForm
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
            groupBox1 = new GroupBox();
            buttonSetMaxSizeReset = new Button();
            buttonSetMaxSize = new Button();
            textBoxSetMaxSize = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSetMaxSizeReset);
            groupBox1.Controls.Add(buttonSetMaxSize);
            groupBox1.Location = new Point(12, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(791, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // buttonSetMaxSizeReset
            // 
            buttonSetMaxSizeReset.Location = new Point(410, 80);
            buttonSetMaxSizeReset.Name = "buttonSetMaxSizeReset";
            buttonSetMaxSizeReset.Size = new Size(201, 46);
            buttonSetMaxSizeReset.TabIndex = 1;
            buttonSetMaxSizeReset.Text = "Сбросить";
            buttonSetMaxSizeReset.UseVisualStyleBackColor = true;
            buttonSetMaxSizeReset.Click += buttonSetMaxSizeReset_Click;
            // 
            // buttonSetMaxSize
            // 
            buttonSetMaxSize.Location = new Point(189, 80);
            buttonSetMaxSize.Name = "buttonSetMaxSize";
            buttonSetMaxSize.Size = new Size(206, 46);
            buttonSetMaxSize.TabIndex = 0;
            buttonSetMaxSize.Text = "Задать размер";
            buttonSetMaxSize.UseVisualStyleBackColor = true;
            buttonSetMaxSize.Click += buttonSetMaxSize_Click;
            // 
            // textBoxSetMaxSize
            // 
            textBoxSetMaxSize.Location = new Point(242, 77);
            textBoxSetMaxSize.Name = "textBoxSetMaxSize";
            textBoxSetMaxSize.Size = new Size(329, 39);
            textBoxSetMaxSize.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 32);
            label1.Name = "label1";
            label1.Size = new Size(299, 32);
            label1.TabIndex = 2;
            label1.Text = "Введите размер очереди:";
            // 
            // SetMaxForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(827, 326);
            Controls.Add(label1);
            Controls.Add(textBoxSetMaxSize);
            Controls.Add(groupBox1);
            Name = "SetMaxForm";
            Text = "Размер очереди";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonSetMaxSizeReset;
        private Button buttonSetMaxSize;
        private TextBox textBoxSetMaxSize;
        private Label label1;
    }
}