namespace WarehouseEN1
{
    partial class OrderForm
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
            this.OrderList = new System.Windows.Forms.ListBox();
            this.ProductPageRBTN = new System.Windows.Forms.RadioButton();
            this.CustomerPageORBTN = new System.Windows.Forms.RadioButton();
            this.OrderPageLable = new System.Windows.Forms.Label();
            this.MenuLable = new System.Windows.Forms.Label();
            this.BatchProcessButton = new System.Windows.Forms.Button();
            this.DispatchedOrdersButton = new System.Windows.Forms.Button();
            this.PendingOrdersButton = new System.Windows.Forms.Button();
            this.OrderDisplayList = new System.Windows.Forms.ListBox();
            this.MakeNewOrderPage = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // OrderList
            // 
            this.OrderList.FormattingEnabled = true;
            this.OrderList.ItemHeight = 20;
            this.OrderList.Location = new System.Drawing.Point(11, 38);
            this.OrderList.Name = "OrderList";
            this.OrderList.Size = new System.Drawing.Size(717, 204);
            this.OrderList.TabIndex = 0;
            this.OrderList.SelectedIndexChanged += new System.EventHandler(this.OrderList_SelectedIndexChanged);
            // 
            // ProductPageRBTN
            // 
            this.ProductPageRBTN.AutoSize = true;
            this.ProductPageRBTN.Location = new System.Drawing.Point(764, 38);
            this.ProductPageRBTN.Name = "ProductPageRBTN";
            this.ProductPageRBTN.Size = new System.Drawing.Size(117, 24);
            this.ProductPageRBTN.TabIndex = 1;
            this.ProductPageRBTN.TabStop = true;
            this.ProductPageRBTN.Text = "Product Page";
            this.ProductPageRBTN.UseVisualStyleBackColor = true;
            this.ProductPageRBTN.CheckedChanged += new System.EventHandler(this.ProductPageRBTN_CheckedChanged);
            // 
            // CustomerPageORBTN
            // 
            this.CustomerPageORBTN.AutoSize = true;
            this.CustomerPageORBTN.Location = new System.Drawing.Point(764, 79);
            this.CustomerPageORBTN.Name = "CustomerPageORBTN";
            this.CustomerPageORBTN.Size = new System.Drawing.Size(129, 24);
            this.CustomerPageORBTN.TabIndex = 2;
            this.CustomerPageORBTN.TabStop = true;
            this.CustomerPageORBTN.Text = "Customer Page";
            this.CustomerPageORBTN.UseVisualStyleBackColor = true;
            this.CustomerPageORBTN.CheckedChanged += new System.EventHandler(this.CustomerPageORBTN_CheckedChanged);
            // 
            // OrderPageLable
            // 
            this.OrderPageLable.AutoSize = true;
            this.OrderPageLable.Location = new System.Drawing.Point(764, 121);
            this.OrderPageLable.Name = "OrderPageLable";
            this.OrderPageLable.Size = new System.Drawing.Size(132, 20);
            this.OrderPageLable.TabIndex = 3;
            this.OrderPageLable.Text = "Order Page (Now) ";
            // 
            // MenuLable
            // 
            this.MenuLable.AutoSize = true;
            this.MenuLable.Location = new System.Drawing.Point(764, 9);
            this.MenuLable.Name = "MenuLable";
            this.MenuLable.Size = new System.Drawing.Size(82, 20);
            this.MenuLable.TabIndex = 4;
            this.MenuLable.Text = "Page Menu";
            // 
            // BatchProcessButton
            // 
            this.BatchProcessButton.Location = new System.Drawing.Point(11, 259);
            this.BatchProcessButton.Name = "BatchProcessButton";
            this.BatchProcessButton.Size = new System.Drawing.Size(121, 65);
            this.BatchProcessButton.TabIndex = 5;
            this.BatchProcessButton.Text = "Batch-Process";
            this.BatchProcessButton.UseVisualStyleBackColor = true;
            this.BatchProcessButton.Click += new System.EventHandler(this.BatchProcessButton_Click);
            // 
            // DispatchedOrdersButton
            // 
            this.DispatchedOrdersButton.Location = new System.Drawing.Point(11, 343);
            this.DispatchedOrdersButton.Name = "DispatchedOrdersButton";
            this.DispatchedOrdersButton.Size = new System.Drawing.Size(121, 70);
            this.DispatchedOrdersButton.TabIndex = 6;
            this.DispatchedOrdersButton.Text = "Display Dispatched Orders";
            this.DispatchedOrdersButton.UseVisualStyleBackColor = true;
            this.DispatchedOrdersButton.Click += new System.EventHandler(this.DispatchedOrdersButton_Click);
            // 
            // PendingOrdersButton
            // 
            this.PendingOrdersButton.Location = new System.Drawing.Point(11, 433);
            this.PendingOrdersButton.Name = "PendingOrdersButton";
            this.PendingOrdersButton.Size = new System.Drawing.Size(120, 60);
            this.PendingOrdersButton.TabIndex = 7;
            this.PendingOrdersButton.Text = "Display Pending Orders";
            this.PendingOrdersButton.UseVisualStyleBackColor = true;
            this.PendingOrdersButton.Click += new System.EventHandler(this.PendingOrdersButton_Click);
            // 
            // OrderDisplayList
            // 
            this.OrderDisplayList.FormattingEnabled = true;
            this.OrderDisplayList.ItemHeight = 20;
            this.OrderDisplayList.Location = new System.Drawing.Point(157, 263);
            this.OrderDisplayList.Name = "OrderDisplayList";
            this.OrderDisplayList.Size = new System.Drawing.Size(570, 224);
            this.OrderDisplayList.TabIndex = 8;
            this.OrderDisplayList.SelectedIndexChanged += new System.EventHandler(this.OrderDisplayList_SelectedIndexChanged);
            // 
            // MakeNewOrderPage
            // 
            this.MakeNewOrderPage.AutoSize = true;
            this.MakeNewOrderPage.Location = new System.Drawing.Point(764, 163);
            this.MakeNewOrderPage.Name = "MakeNewOrderPage";
            this.MakeNewOrderPage.Size = new System.Drawing.Size(142, 24);
            this.MakeNewOrderPage.TabIndex = 9;
            this.MakeNewOrderPage.TabStop = true;
            this.MakeNewOrderPage.Text = "Make New Order";
            this.MakeNewOrderPage.UseVisualStyleBackColor = true;
            this.MakeNewOrderPage.CheckedChanged += new System.EventHandler(this.MakeNewOrderPage_CheckedChanged);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 516);
            this.Controls.Add(this.MakeNewOrderPage);
            this.Controls.Add(this.OrderDisplayList);
            this.Controls.Add(this.PendingOrdersButton);
            this.Controls.Add(this.DispatchedOrdersButton);
            this.Controls.Add(this.BatchProcessButton);
            this.Controls.Add(this.MenuLable);
            this.Controls.Add(this.OrderPageLable);
            this.Controls.Add(this.CustomerPageORBTN);
            this.Controls.Add(this.ProductPageRBTN);
            this.Controls.Add(this.OrderList);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OrderList;
        private System.Windows.Forms.RadioButton ProductPageRBTN;
        private System.Windows.Forms.RadioButton CustomerPageORBTN;
        private System.Windows.Forms.Label OrderPageLable;
        private System.Windows.Forms.Label MenuLable;
        private System.Windows.Forms.Button BatchProcessButton;
        private System.Windows.Forms.Button DispatchedOrdersButton;
        private System.Windows.Forms.Button PendingOrdersButton;
        private System.Windows.Forms.ListBox OrderDisplayList;
        private System.Windows.Forms.RadioButton MakeNewOrderPage;
    }
}