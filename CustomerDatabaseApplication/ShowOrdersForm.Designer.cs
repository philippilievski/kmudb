namespace CustomerDatabaseApplication
{
    partial class ShowOrdersForm
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
            this.dataGridShowOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShowOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridShowOrders
            // 
            this.dataGridShowOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShowOrders.Location = new System.Drawing.Point(12, 12);
            this.dataGridShowOrders.Name = "dataGridShowOrders";
            this.dataGridShowOrders.Size = new System.Drawing.Size(776, 426);
            this.dataGridShowOrders.TabIndex = 0;
            // 
            // ShowOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridShowOrders);
            this.Name = "ShowOrdersForm";
            this.Text = "ShowOrders";
            this.Load += new System.EventHandler(this.ShowOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShowOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridShowOrders;
    }
}