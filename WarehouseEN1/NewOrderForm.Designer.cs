namespace WarehouseEN1
{
    partial class NewOrderForm
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
            this.ProductList = new System.Windows.Forms.ListBox();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.ProductAmountTextBox = new System.Windows.Forms.TextBox();
            this.CartList = new System.Windows.Forms.ListBox();
            this.CostumerTextBox = new System.Windows.Forms.TextBox();
            this.TotalCostLable = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.PlaceOrderButton = new System.Windows.Forms.Button();
            this.DeleteOrderButton = new System.Windows.Forms.Button();
            this.PageMenuLable = new System.Windows.Forms.Label();
            this.ProductPageN = new System.Windows.Forms.RadioButton();
            this.CustomerPageN = new System.Windows.Forms.RadioButton();
            this.OrderPageN = new System.Windows.Forms.RadioButton();
            this.NewOrderLable = new System.Windows.Forms.Label();
            this.PayRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ProductList
            // 
            this.ProductList.FormattingEnabled = true;
            this.ProductList.ItemHeight = 20;
            this.ProductList.Location = new System.Drawing.Point(31, 12);
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(300, 284);
            this.ProductList.TabIndex = 0;
            this.ProductList.SelectedIndexChanged += new System.EventHandler(this.ProductList_SelectedIndexChanged);
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Location = new System.Drawing.Point(146, 313);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(117, 32);
            this.AddToCartButton.TabIndex = 2;
            this.AddToCartButton.Text = "Add To Cart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // ProductAmountTextBox
            // 
            this.ProductAmountTextBox.Location = new System.Drawing.Point(31, 313);
            this.ProductAmountTextBox.Name = "ProductAmountTextBox";
            this.ProductAmountTextBox.PlaceholderText = "Amount";
            this.ProductAmountTextBox.Size = new System.Drawing.Size(63, 27);
            this.ProductAmountTextBox.TabIndex = 3;
            this.ProductAmountTextBox.TextChanged += new System.EventHandler(this.ProductAmountTextBox_TextChanged);
            // 
            // CartList
            // 
            this.CartList.FormattingEnabled = true;
            this.CartList.ItemHeight = 20;
            this.CartList.Location = new System.Drawing.Point(337, 141);
            this.CartList.Name = "CartList";
            this.CartList.Size = new System.Drawing.Size(184, 204);
            this.CartList.TabIndex = 4;
            this.CartList.SelectedIndexChanged += new System.EventHandler(this.CartList_SelectedIndexChanged);
            // 
            // CostumerTextBox
            // 
            this.CostumerTextBox.Location = new System.Drawing.Point(337, 381);
            this.CostumerTextBox.Name = "CostumerTextBox";
            this.CostumerTextBox.PlaceholderText = "Customer number";
            this.CostumerTextBox.Size = new System.Drawing.Size(180, 27);
            this.CostumerTextBox.TabIndex = 5;
            this.CostumerTextBox.TextChanged += new System.EventHandler(this.CostumerTextBox_TextChanged);
            // 
            // TotalCostLable
            // 
            this.TotalCostLable.AutoSize = true;
            this.TotalCostLable.Location = new System.Drawing.Point(337, 348);
            this.TotalCostLable.Name = "TotalCostLable";
            this.TotalCostLable.Size = new System.Drawing.Size(75, 20);
            this.TotalCostLable.TabIndex = 6;
            this.TotalCostLable.Text = "Total Cost";
            this.TotalCostLable.Click += new System.EventHandler(this.TotalCostLable_Click);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(337, 426);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.PlaceholderText = "Address";
            this.AddressTextBox.Size = new System.Drawing.Size(179, 27);
            this.AddressTextBox.TabIndex = 7;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // PlaceOrderButton
            // 
            this.PlaceOrderButton.Location = new System.Drawing.Point(545, 426);
            this.PlaceOrderButton.Name = "PlaceOrderButton";
            this.PlaceOrderButton.Size = new System.Drawing.Size(110, 62);
            this.PlaceOrderButton.TabIndex = 8;
            this.PlaceOrderButton.Text = "Place Order";
            this.PlaceOrderButton.UseVisualStyleBackColor = true;
            this.PlaceOrderButton.Click += new System.EventHandler(this.PlaceOrderButton_Click);
            // 
            // DeleteOrderButton
            // 
            this.DeleteOrderButton.Location = new System.Drawing.Point(674, 457);
            this.DeleteOrderButton.Name = "DeleteOrderButton";
            this.DeleteOrderButton.Size = new System.Drawing.Size(104, 30);
            this.DeleteOrderButton.TabIndex = 9;
            this.DeleteOrderButton.Text = "Delete Order";
            this.DeleteOrderButton.UseVisualStyleBackColor = true;
            this.DeleteOrderButton.Click += new System.EventHandler(this.DeleteOrderButton_Click);
            // 
            // PageMenuLable
            // 
            this.PageMenuLable.AutoSize = true;
            this.PageMenuLable.Location = new System.Drawing.Point(674, 27);
            this.PageMenuLable.Name = "PageMenuLable";
            this.PageMenuLable.Size = new System.Drawing.Size(82, 20);
            this.PageMenuLable.TabIndex = 10;
            this.PageMenuLable.Text = "Page menu";
            // 
            // ProductPageN
            // 
            this.ProductPageN.AutoSize = true;
            this.ProductPageN.Location = new System.Drawing.Point(674, 66);
            this.ProductPageN.Name = "ProductPageN";
            this.ProductPageN.Size = new System.Drawing.Size(117, 24);
            this.ProductPageN.TabIndex = 11;
            this.ProductPageN.TabStop = true;
            this.ProductPageN.Text = "Product Page";
            this.ProductPageN.UseVisualStyleBackColor = true;
            this.ProductPageN.CheckedChanged += new System.EventHandler(this.ProductPageN_CheckedChanged);
            // 
            // CustomerPageN
            // 
            this.CustomerPageN.AutoSize = true;
            this.CustomerPageN.Location = new System.Drawing.Point(674, 107);
            this.CustomerPageN.Name = "CustomerPageN";
            this.CustomerPageN.Size = new System.Drawing.Size(129, 24);
            this.CustomerPageN.TabIndex = 12;
            this.CustomerPageN.TabStop = true;
            this.CustomerPageN.Text = "Customer Page";
            this.CustomerPageN.UseVisualStyleBackColor = true;
            this.CustomerPageN.CheckedChanged += new System.EventHandler(this.CustomerPageN_CheckedChanged);
            // 
            // OrderPageN
            // 
            this.OrderPageN.AutoSize = true;
            this.OrderPageN.Location = new System.Drawing.Point(674, 150);
            this.OrderPageN.Name = "OrderPageN";
            this.OrderPageN.Size = new System.Drawing.Size(104, 24);
            this.OrderPageN.TabIndex = 13;
            this.OrderPageN.TabStop = true;
            this.OrderPageN.Text = "Order Page";
            this.OrderPageN.UseVisualStyleBackColor = true;
            this.OrderPageN.CheckedChanged += new System.EventHandler(this.OrderPageN_CheckedChanged);
            // 
            // NewOrderLable
            // 
            this.NewOrderLable.AutoSize = true;
            this.NewOrderLable.Location = new System.Drawing.Point(676, 195);
            this.NewOrderLable.Name = "NewOrderLable";
            this.NewOrderLable.Size = new System.Drawing.Size(166, 20);
            this.NewOrderLable.TabIndex = 14;
            this.NewOrderLable.Text = "Make New Order (Now)";
            // 
            // PayRadioButton
            // 
            this.PayRadioButton.AutoSize = true;
            this.PayRadioButton.Location = new System.Drawing.Point(337, 464);
            this.PayRadioButton.Name = "PayRadioButton";
            this.PayRadioButton.Size = new System.Drawing.Size(52, 24);
            this.PayRadioButton.TabIndex = 15;
            this.PayRadioButton.TabStop = true;
            this.PayRadioButton.Text = "Pay";
            this.PayRadioButton.UseVisualStyleBackColor = true;
            this.PayRadioButton.CheckedChanged += new System.EventHandler(this.PayRadioButton_CheckedChanged);
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 507);
            this.Controls.Add(this.PayRadioButton);
            this.Controls.Add(this.NewOrderLable);
            this.Controls.Add(this.OrderPageN);
            this.Controls.Add(this.CustomerPageN);
            this.Controls.Add(this.ProductPageN);
            this.Controls.Add(this.PageMenuLable);
            this.Controls.Add(this.DeleteOrderButton);
            this.Controls.Add(this.PlaceOrderButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.TotalCostLable);
            this.Controls.Add(this.CostumerTextBox);
            this.Controls.Add(this.CartList);
            this.Controls.Add(this.ProductAmountTextBox);
            this.Controls.Add(this.AddToCartButton);
            this.Controls.Add(this.ProductList);
            this.Name = "NewOrderForm";
            this.Text = "NewOrder";
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProductList;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.TextBox ProductAmountTextBox;
        private System.Windows.Forms.ListBox CartList;
        private System.Windows.Forms.TextBox CostumerTextBox;
        private System.Windows.Forms.Label TotalCostLable;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button PlaceOrderButton;
        private System.Windows.Forms.Button DeleteOrderButton;
        private System.Windows.Forms.Label PageMenuLable;
        private System.Windows.Forms.RadioButton ProductPageN;
        private System.Windows.Forms.RadioButton CustomerPageN;
        private System.Windows.Forms.RadioButton OrderPageN;
        private System.Windows.Forms.Label NewOrderLable;
        private System.Windows.Forms.RadioButton PayRadioButton;
    }
}