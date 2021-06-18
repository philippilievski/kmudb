namespace CustomerDatabaseApplication
{
    partial class ProductsForm
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
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label18;
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dataGridViewShowProducts = new System.Windows.Forms.DataGridView();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.cmbBoxCustomerID = new System.Windows.Forms.ComboBox();
            this.CmbBoxProduct = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            label16 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(328, 154);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 127;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // dataGridViewShowProducts
            // 
            this.dataGridViewShowProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowProducts.Location = new System.Drawing.Point(549, 12);
            this.dataGridViewShowProducts.Name = "dataGridViewShowProducts";
            this.dataGridViewShowProducts.Size = new System.Drawing.Size(448, 165);
            this.dataGridViewShowProducts.TabIndex = 126;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(310, 67);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(0, 13);
            this.lblLastName.TabIndex = 125;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(164, 67);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(0, 13);
            this.lblFirstName.TabIndex = 124;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            label16.ForeColor = System.Drawing.Color.Black;
            label16.Location = new System.Drawing.Point(13, 24);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(154, 27);
            label16.TabIndex = 123;
            label16.Text = "Kundennummer";
            // 
            // cmbBoxCustomerID
            // 
            this.cmbBoxCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCustomerID.FormattingEnabled = true;
            this.cmbBoxCustomerID.Location = new System.Drawing.Point(13, 64);
            this.cmbBoxCustomerID.Name = "cmbBoxCustomerID";
            this.cmbBoxCustomerID.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxCustomerID.TabIndex = 122;
            // 
            // CmbBoxProduct
            // 
            this.CmbBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxProduct.FormattingEnabled = true;
            this.CmbBoxProduct.Location = new System.Drawing.Point(13, 156);
            this.CmbBoxProduct.Name = "CmbBoxProduct";
            this.CmbBoxProduct.Size = new System.Drawing.Size(121, 21);
            this.CmbBoxProduct.TabIndex = 121;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            label18.ForeColor = System.Drawing.Color.Black;
            label18.Location = new System.Drawing.Point(13, 100);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(105, 27);
            label18.TabIndex = 120;
            label18.Text = "Bestellung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 119;
            this.label6.Text = "Anzahl";
            // 
            // txtBoxAmount
            // 
            this.txtBoxAmount.Location = new System.Drawing.Point(185, 157);
            this.txtBoxAmount.Name = "txtBoxAmount";
            this.txtBoxAmount.Size = new System.Drawing.Size(110, 20);
            this.txtBoxAmount.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 117;
            this.label3.Text = "Produkt";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(934, 415);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(181, 84);
            this.btnFinish.TabIndex = 128;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 511);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dataGridViewShowProducts);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(label16);
            this.Controls.Add(this.cmbBoxCustomerID);
            this.Controls.Add(this.CmbBoxProduct);
            this.Controls.Add(label18);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxAmount);
            this.Controls.Add(this.label3);
            this.Name = "ProductsForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView dataGridViewShowProducts;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.ComboBox cmbBoxCustomerID;
        private System.Windows.Forms.ComboBox CmbBoxProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFinish;
    }
}