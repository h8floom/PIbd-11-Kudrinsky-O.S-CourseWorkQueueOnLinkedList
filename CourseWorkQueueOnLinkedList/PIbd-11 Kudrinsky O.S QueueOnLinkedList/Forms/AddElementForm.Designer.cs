﻿namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms
{
    partial class AddElementForm
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
            buttonReset = new Button();
            buttonAddEl = new Button();
            labelAddElement = new Label();
            numericUpDown = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonReset);
            groupBox1.Controls.Add(buttonAddEl);
            groupBox1.Location = new Point(12, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(829, 124);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(431, 48);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(200, 46);
            buttonReset.TabIndex = 1;
            buttonReset.Text = "Сбросить";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonAddEl
            // 
            buttonAddEl.Location = new Point(204, 48);
            buttonAddEl.Name = "buttonAddEl";
            buttonAddEl.Size = new Size(191, 46);
            buttonAddEl.TabIndex = 0;
            buttonAddEl.Text = "Добавить";
            buttonAddEl.UseVisualStyleBackColor = true;
            buttonAddEl.Click += buttonAddEl_Click;
            // 
            // labelAddElement
            // 
            labelAddElement.AutoSize = true;
            labelAddElement.Location = new Point(316, 9);
            labelAddElement.Name = "labelAddElement";
            labelAddElement.Size = new Size(221, 32);
            labelAddElement.TabIndex = 2;
            labelAddElement.Text = "Введите значение:";
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(306, 58);
            numericUpDown.Maximum = new decimal(new int[] { int.MaxValue,
            0,
            0,
            0 });
            numericUpDown.Minimum = new decimal(new int[] {int.MinValue,
            0,
            0,
            int.MinValue});
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(240, 39);
            numericUpDown.TabIndex = 3;
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            // 
            // AddElementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(853, 248);
            Controls.Add(numericUpDown);
            Controls.Add(labelAddElement);
            Controls.Add(groupBox1);
            Name = "AddElementForm";
            Text = "Добавление элемента";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label labelAddElement;
        private Button buttonReset;
        private Button buttonAddEl;
        private NumericUpDown numericUpDown;
    }
}