namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox = new GroupBox();
            labelQueueSize = new Label();
            buttonSetMaxSize = new Button();
            buttonInformation = new Button();
            buttonUpdate = new Button();
            buttonDeleteElement = new Button();
            buttonAddElement = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            LoadToolStripMenuItem = new ToolStripMenuItem();
            buttonBackStep = new Button();
            buttonForwardStep = new Button();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(buttonForwardStep);
            groupBox.Controls.Add(buttonBackStep);
            groupBox.Controls.Add(labelQueueSize);
            groupBox.Controls.Add(buttonSetMaxSize);
            groupBox.Controls.Add(buttonInformation);
            groupBox.Controls.Add(buttonUpdate);
            groupBox.Controls.Add(buttonDeleteElement);
            groupBox.Controls.Add(buttonAddElement);
            groupBox.Location = new Point(12, 89);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(400, 751);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Панель инструментов";
            // 
            // labelQueueSize
            // 
            labelQueueSize.AutoSize = true;
            labelQueueSize.Location = new Point(6, 271);
            labelQueueSize.Name = "labelQueueSize";
            labelQueueSize.Size = new Size(78, 32);
            labelQueueSize.TabIndex = 3;
            labelQueueSize.Text = "label1";
            // 
            // buttonSetMaxSize
            // 
            buttonSetMaxSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSetMaxSize.Location = new Point(6, 178);
            buttonSetMaxSize.Name = "buttonSetMaxSize";
            buttonSetMaxSize.Size = new Size(388, 46);
            buttonSetMaxSize.TabIndex = 4;
            buttonSetMaxSize.Text = "Задать размер";
            buttonSetMaxSize.UseVisualStyleBackColor = true;
            buttonSetMaxSize.Click += buttonSetMaxSize_Click;
            // 
            // buttonInformation
            // 
            buttonInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonInformation.Location = new Point(6, 662);
            buttonInformation.Name = "buttonInformation";
            buttonInformation.Size = new Size(388, 46);
            buttonInformation.TabIndex = 2;
            buttonInformation.Text = "Информация о программе";
            buttonInformation.UseVisualStyleBackColor = true;
            buttonInformation.Click += buttonInformation_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonUpdate.Location = new Point(6, 610);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(388, 46);
            buttonUpdate.TabIndex = 3;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteElement
            // 
            buttonDeleteElement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonDeleteElement.Location = new Point(6, 126);
            buttonDeleteElement.Name = "buttonDeleteElement";
            buttonDeleteElement.Size = new Size(388, 46);
            buttonDeleteElement.TabIndex = 2;
            buttonDeleteElement.Text = "Удалить элемент";
            buttonDeleteElement.UseVisualStyleBackColor = true;
            buttonDeleteElement.Click += buttonDeleteElement_Click;
            // 
            // buttonAddElement
            // 
            buttonAddElement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddElement.Location = new Point(6, 74);
            buttonAddElement.Name = "buttonAddElement";
            buttonAddElement.Size = new Size(388, 46);
            buttonAddElement.TabIndex = 1;
            buttonAddElement.Text = "Добавить элемент";
            buttonAddElement.UseVisualStyleBackColor = true;
            buttonAddElement.Click += buttonAddElement_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(418, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1422, 736);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1852, 40);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, LoadToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(90, 36);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveToolStripMenuItem.Size = new Size(343, 44);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // LoadToolStripMenuItem
            // 
            LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            LoadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            LoadToolStripMenuItem.Size = new Size(343, 44);
            LoadToolStripMenuItem.Text = "Загрузить";
            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // buttonBackStep
            // 
            buttonBackStep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonBackStep.Location = new Point(6, 409);
            buttonBackStep.Name = "buttonBackStep";
            buttonBackStep.Size = new Size(186, 46);
            buttonBackStep.TabIndex = 5;
            buttonBackStep.Text = "Назад";
            buttonBackStep.UseVisualStyleBackColor = true;
            buttonBackStep.Click += buttonBackStep_Click;
            // 
            // buttonForwardStep
            // 
            buttonForwardStep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonForwardStep.Location = new Point(208, 409);
            buttonForwardStep.Name = "buttonForwardStep";
            buttonForwardStep.Size = new Size(186, 46);
            buttonForwardStep.TabIndex = 6;
            buttonForwardStep.Text = "Вперед";
            buttonForwardStep.UseVisualStyleBackColor = true;
            buttonForwardStep.Click += buttonForwardStep_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1852, 857);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "АТД Очередь";
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox;
        private Button buttonInformation;
        private Button buttonUpdate;
        private Button buttonDeleteElement;
        private Button buttonAddElement;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private Button buttonSetMaxSize;
        private Label labelQueueSize;
        private Button buttonBackStep;
        private Button buttonForwardStep;
    }
}
