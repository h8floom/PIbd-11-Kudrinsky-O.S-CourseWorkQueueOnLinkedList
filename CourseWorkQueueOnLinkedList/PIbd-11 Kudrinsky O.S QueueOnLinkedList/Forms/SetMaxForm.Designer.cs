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
            label1 = new Label();
            numericUpDownSize = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).BeginInit();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 37);
            label1.Name = "label1";
            label1.Size = new Size(299, 32);
            label1.TabIndex = 2;
            label1.Text = "Введите размер очереди:";
            // 
            // numericUpDownSize
            // 
            numericUpDownSize.Location = new Point(295, 89);
            numericUpDownSize.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            numericUpDownSize.Name = "numericUpDownSize";
            numericUpDownSize.Size = new Size(240, 39);
            numericUpDownSize.TabIndex = 3;
            numericUpDownSize.ValueChanged += numericUpDownSize_ValueChanged;
            // 
            // SetMaxForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(827, 326);
            Controls.Add(numericUpDownSize);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "SetMaxForm";
            Text = "Размер очереди";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonSetMaxSizeReset;
        private Button buttonSetMaxSize;
        private Label label1;
        private NumericUpDown numericUpDownSize;
    }
}