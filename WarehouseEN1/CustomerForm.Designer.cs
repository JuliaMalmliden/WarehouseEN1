namespace WarehouseEN1
{
    partial class CustomerList
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
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.CustomerListBox = new System.Windows.Forms.ListBox();
            this.CustomerNumber = new System.Windows.Forms.TextBox();
            this.CustomerEmail = new System.Windows.Forms.TextBox();
            this.CustomerDisplayListBox = new System.Windows.Forms.ListBox();
            this.CustomerAddButton = new System.Windows.Forms.Button();
            this.CustomerUpdateButton = new System.Windows.Forms.Button();
            this.PreviousOrdersButton = new System.Windows.Forms.Button();
            this.RecentOrdersButton = new System.Windows.Forms.Button();
            this.CustomerPageMenu = new System.Windows.Forms.Label();
            this.ProductPageC = new System.Windows.Forms.RadioButton();
            this.CustomerPageLable = new System.Windows.Forms.Label();
            this.OrderPageC = new System.Windows.Forms.RadioButton();
            this.MakeNewOrderPageC = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(12, 234);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.PlaceholderText = "Name";
            this.CustomerName.Size = new System.Drawing.Size(142, 27);
            this.CustomerName.TabIndex = 1;
            this.CustomerName.TextChanged += new System.EventHandler(this.CustomerName_TextChanged);
            // 
            // CustomerListBox
            // 
            this.CustomerListBox.FormattingEnabled = true;
            this.CustomerListBox.ItemHeight = 20;
            this.CustomerListBox.Location = new System.Drawing.Point(12, 14);
            this.CustomerListBox.Name = "CustomerListBox";
            this.CustomerListBox.Size = new System.Drawing.Size(576, 204);
            this.CustomerListBox.TabIndex = 2;
            this.CustomerListBox.SelectedIndexChanged += new System.EventHandler(this.CustomerListBox_SelectedIndexChanged);
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.Location = new System.Drawing.Point(160, 234);
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.PlaceholderText = "Number";
            this.CustomerNumber.Size = new System.Drawing.Size(173, 27);
            this.CustomerNumber.TabIndex = 3;
            this.CustomerNumber.TextChanged += new System.EventHandler(this.CustomerNumber_TextChanged);
            // 
            // CustomerEmail
            // 
            this.CustomerEmail.Location = new System.Drawing.Point(339, 234);
            this.CustomerEmail.Name = "CustomerEmail";
            this.CustomerEmail.PlaceholderText = "E-mail";
            this.CustomerEmail.Size = new System.Drawing.Size(249, 27);
            this.CustomerEmail.TabIndex = 4;
            this.CustomerEmail.TextChanged += new System.EventHandler(this.CustomerEmail_TextChanged);
            // 
            // CustomerDisplayListBox
            // 
            this.CustomerDisplayListBox.FormattingEnabled = true;
            this.CustomerDisplayListBox.ItemHeight = 20;
            this.CustomerDisplayListBox.Location = new System.Drawing.Point(12, 275);
            this.CustomerDisplayListBox.Name = "CustomerDisplayListBox";
            this.CustomerDisplayListBox.Size = new System.Drawing.Size(575, 144);
            this.CustomerDisplayListBox.TabIndex = 5;
            this.CustomerDisplayListBox.SelectedIndexChanged += new System.EventHandler(this.CustomerDisplayListBox_SelectedIndexChanged);
            // 
            // CustomerAddButton
            // 
            this.CustomerAddButton.Location = new System.Drawing.Point(594, 216);
            this.CustomerAddButton.Name = "CustomerAddButton";
            this.CustomerAddButton.Size = new System.Drawing.Size(94, 62);
            this.CustomerAddButton.TabIndex = 6;
            this.CustomerAddButton.Text = "Add";
            this.CustomerAddButton.UseVisualStyleBackColor = true;
            this.CustomerAddButton.Click += new System.EventHandler(this.CustomerAddButton_Click);
            // 
            // CustomerUpdateButton
            // 
            this.CustomerUpdateButton.Location = new System.Drawing.Point(694, 216);
            this.CustomerUpdateButton.Name = "CustomerUpdateButton";
            this.CustomerUpdateButton.Size = new System.Drawing.Size(94, 62);
            this.CustomerUpdateButton.TabIndex = 7;
            this.CustomerUpdateButton.Text = "Update";
            this.CustomerUpdateButton.UseVisualStyleBackColor = true;
            this.CustomerUpdateButton.Click += new System.EventHandler(this.CustomerUpdateButton_Click);
            // 
            // PreviousOrdersButton
            // 
            this.PreviousOrdersButton.Location = new System.Drawing.Point(599, 287);
            this.PreviousOrdersButton.Name = "PreviousOrdersButton";
            this.PreviousOrdersButton.Size = new System.Drawing.Size(188, 63);
            this.PreviousOrdersButton.TabIndex = 8;
            this.PreviousOrdersButton.Text = "Display previous orders";
            this.PreviousOrdersButton.UseVisualStyleBackColor = true;
            this.PreviousOrdersButton.Click += new System.EventHandler(this.PreviousOrdersButton_Click);
            // 
            // RecentOrdersButton
            // 
            this.RecentOrdersButton.Location = new System.Drawing.Point(600, 360);
            this.RecentOrdersButton.Name = "RecentOrdersButton";
            this.RecentOrdersButton.Size = new System.Drawing.Size(186, 58);
            this.RecentOrdersButton.TabIndex = 9;
            this.RecentOrdersButton.Text = "Display recent orders";
            this.RecentOrdersButton.UseVisualStyleBackColor = true;
            this.RecentOrdersButton.Click += new System.EventHandler(this.RecentOrdersButton_Click);
            // 
            // CustomerPageMenu
            // 
            this.CustomerPageMenu.AutoSize = true;
            this.CustomerPageMenu.Location = new System.Drawing.Point(606, 14);
            this.CustomerPageMenu.Name = "CustomerPageMenu";
            this.CustomerPageMenu.Size = new System.Drawing.Size(82, 20);
            this.CustomerPageMenu.TabIndex = 10;
            this.CustomerPageMenu.Text = "Page Menu";
            // 
            // ProductPageC
            // 
            this.ProductPageC.AutoSize = true;
            this.ProductPageC.Location = new System.Drawing.Point(606, 53);
            this.ProductPageC.Name = "ProductPageC";
            this.ProductPageC.Size = new System.Drawing.Size(117, 24);
            this.ProductPageC.TabIndex = 11;
            this.ProductPageC.TabStop = true;
            this.ProductPageC.Text = "Product Page";
            this.ProductPageC.UseVisualStyleBackColor = true;
            this.ProductPageC.CheckedChanged += new System.EventHandler(this.ProductPageC_CheckedChanged);
            // 
            // CustomerPageLable
            // 
            this.CustomerPageLable.AutoSize = true;
            this.CustomerPageLable.Location = new System.Drawing.Point(627, 90);
            this.CustomerPageLable.Name = "CustomerPageLable";
            this.CustomerPageLable.Size = new System.Drawing.Size(153, 20);
            this.CustomerPageLable.TabIndex = 12;
            this.CustomerPageLable.Text = "Customer Page (Now)";
            // 
            // OrderPageC
            // 
            this.OrderPageC.AutoSize = true;
            this.OrderPageC.Location = new System.Drawing.Point(606, 130);
            this.OrderPageC.Name = "OrderPageC";
            this.OrderPageC.Size = new System.Drawing.Size(104, 24);
            this.OrderPageC.TabIndex = 13;
            this.OrderPageC.TabStop = true;
            this.OrderPageC.Text = "Order Page";
            this.OrderPageC.UseVisualStyleBackColor = true;
            this.OrderPageC.CheckedChanged += new System.EventHandler(this.OrderPageC_CheckedChanged);
            // 
            // MakeNewOrderPageC
            // 
            this.MakeNewOrderPageC.AutoSize = true;
            this.MakeNewOrderPageC.Location = new System.Drawing.Point(606, 172);
            this.MakeNewOrderPageC.Name = "MakeNewOrderPageC";
            this.MakeNewOrderPageC.Size = new System.Drawing.Size(142, 24);
            this.MakeNewOrderPageC.TabIndex = 14;
            this.MakeNewOrderPageC.TabStop = true;
            this.MakeNewOrderPageC.Text = "Make New Order";
            this.MakeNewOrderPageC.UseVisualStyleBackColor = true;
            this.MakeNewOrderPageC.CheckedChanged += new System.EventHandler(this.MakeNewOrderPageC_CheckedChanged);
            // 
            // CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MakeNewOrderPageC);
            this.Controls.Add(this.OrderPageC);
            this.Controls.Add(this.CustomerPageLable);
            this.Controls.Add(this.ProductPageC);
            this.Controls.Add(this.CustomerPageMenu);
            this.Controls.Add(this.RecentOrdersButton);
            this.Controls.Add(this.PreviousOrdersButton);
            this.Controls.Add(this.CustomerUpdateButton);
            this.Controls.Add(this.CustomerAddButton);
            this.Controls.Add(this.CustomerDisplayListBox);
            this.Controls.Add(this.CustomerEmail);
            this.Controls.Add(this.CustomerNumber);
            this.Controls.Add(this.CustomerListBox);
            this.Controls.Add(this.CustomerName);
            this.Name = "CustomerList";
            this.Text = "CustomerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.ListBox CustomerListBox;
        private System.Windows.Forms.TextBox CustomerNumber;
        private System.Windows.Forms.TextBox CustomerEmail;
        private System.Windows.Forms.ListBox CustomerDisplayListBox;
        private System.Windows.Forms.Button CustomerAddButton;
        private System.Windows.Forms.Button CustomerUpdateButton;
        private System.Windows.Forms.Button PreviousOrdersButton;
        private System.Windows.Forms.Button RecentOrdersButton;
        private System.Windows.Forms.Label CustomerPageMenu;
        private System.Windows.Forms.RadioButton ProductPageC;
        private System.Windows.Forms.Label CustomerPageLable;
        private System.Windows.Forms.RadioButton OrderPageC;
        private System.Windows.Forms.RadioButton MakeNewOrderPageC;
    }
}