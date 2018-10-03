namespace HeirachicalTimetable
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.workGrid = new System.Windows.Forms.DataGridView();
            this.workLineGrid = new System.Windows.Forms.DataGridView();
            this.textBox = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workLineGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // workGrid
            // 
            this.workGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workGrid.Location = new System.Drawing.Point(255, 161);
            this.workGrid.Name = "workGrid";
            this.workGrid.Size = new System.Drawing.Size(628, 325);
            this.workGrid.TabIndex = 0;
            this.workGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workGrid_CellContentClick);
            // 
            // workLineGrid
            // 
            this.workLineGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workLineGrid.Location = new System.Drawing.Point(24, 43);
            this.workLineGrid.Name = "workLineGrid";
            this.workLineGrid.Size = new System.Drawing.Size(648, 89);
            this.workLineGrid.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(24, 161);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 2;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(24, 204);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(100, 23);
            this.calcButton.TabIndex = 3;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 509);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.workLineGrid);
            this.Controls.Add(this.workGrid);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workLineGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView workGrid;
        private System.Windows.Forms.DataGridView workLineGrid;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button calcButton;
    }
}

