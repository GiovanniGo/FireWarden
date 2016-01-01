namespace View
{
    partial class CheckoutForm
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
            this.checkoutButton = new System.Windows.Forms.Button();
            this.catalogTextBox = new System.Windows.Forms.TextBox();
            this.catalogBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.importProductListButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkoutTextBox = new System.Windows.Forms.TextBox();
            this.checkoutBrowseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkoutButton
            // 
            this.checkoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkoutButton.Location = new System.Drawing.Point(626, 67);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(96, 49);
            this.checkoutButton.TabIndex = 0;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // catalogTextBox
            // 
            this.catalogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.catalogTextBox.Location = new System.Drawing.Point(122, 12);
            this.catalogTextBox.Multiline = true;
            this.catalogTextBox.Name = "catalogTextBox";
            this.catalogTextBox.Size = new System.Drawing.Size(448, 49);
            this.catalogTextBox.TabIndex = 1;
            // 
            // catalogBrowseButton
            // 
            this.catalogBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.catalogBrowseButton.Location = new System.Drawing.Point(576, 12);
            this.catalogBrowseButton.Name = "catalogBrowseButton";
            this.catalogBrowseButton.Size = new System.Drawing.Size(44, 49);
            this.catalogBrowseButton.TabIndex = 2;
            this.catalogBrowseButton.Text = "...";
            this.catalogBrowseButton.UseVisualStyleBackColor = true;
            this.catalogBrowseButton.Click += new System.EventHandler(this.catalogBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Price Total:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(101, 181);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(63, 20);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "EMPTY";
            // 
            // importProductListButton
            // 
            this.importProductListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importProductListButton.Location = new System.Drawing.Point(626, 12);
            this.importProductListButton.Name = "importProductListButton";
            this.importProductListButton.Size = new System.Drawing.Size(96, 49);
            this.importProductListButton.TabIndex = 5;
            this.importProductListButton.Text = "Import";
            this.importProductListButton.UseVisualStyleBackColor = true;
            this.importProductListButton.Click += new System.EventHandler(this.importProductListButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Catalog :";
            // 
            // checkoutTextBox
            // 
            this.checkoutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkoutTextBox.Location = new System.Drawing.Point(122, 67);
            this.checkoutTextBox.Multiline = true;
            this.checkoutTextBox.Name = "checkoutTextBox";
            this.checkoutTextBox.Size = new System.Drawing.Size(448, 49);
            this.checkoutTextBox.TabIndex = 7;
            // 
            // checkoutBrowseButton
            // 
            this.checkoutBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkoutBrowseButton.Location = new System.Drawing.Point(576, 67);
            this.checkoutBrowseButton.Name = "checkoutBrowseButton";
            this.checkoutBrowseButton.Size = new System.Drawing.Size(44, 49);
            this.checkoutBrowseButton.TabIndex = 8;
            this.checkoutBrowseButton.Text = "...";
            this.checkoutBrowseButton.UseVisualStyleBackColor = true;
            this.checkoutBrowseButton.Click += new System.EventHandler(this.checkoutBrowseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Checkout List :";
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 219);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkoutBrowseButton);
            this.Controls.Add(this.checkoutTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.importProductListButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.catalogBrowseButton);
            this.Controls.Add(this.catalogTextBox);
            this.Controls.Add(this.checkoutButton);
            this.Name = "CheckoutForm";
            this.Text = "Checkout Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.TextBox catalogTextBox;
        private System.Windows.Forms.Button catalogBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Button importProductListButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox checkoutTextBox;
        private System.Windows.Forms.Button checkoutBrowseButton;
        private System.Windows.Forms.Label label3;
    }
}

