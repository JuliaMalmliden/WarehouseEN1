﻿namespace WarehouseEN1
{
    partial class ProductForm
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
            this.ProductList = new System.Windows.Forms.ListBox();
            this.ProductEditButton = new System.Windows.Forms.Button();
            this.OutOfStockButton = new System.Windows.Forms.Button();
            this.NextRestockButton = new System.Windows.Forms.Button();
            this.ProductPricetextbox = new System.Windows.Forms.TextBox();
            this.ProductStocktextBox = new System.Windows.Forms.TextBox();
            this.ProductDisplayList = new System.Windows.Forms.ListBox();
            this.CustomerPageP = new System.Windows.Forms.RadioButton();
            this.OrderPageP = new System.Windows.Forms.RadioButton();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.ProdNametextBox = new System.Windows.Forms.TextBox();
            this.ProNextRestocktextBox = new System.Windows.Forms.TextBox();
            this.ProductAddButton = new System.Windows.Forms.Button();
            this.ProductpageLable = new System.Windows.Forms.Label();
            this.MakeNewOrderPageP = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ProductList
            // 
            this.ProductList.FormattingEnabled = true;
            this.ProductList.ItemHeight = 20;
            this.ProductList.Location = new System.Drawing.Point(22, 29);
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(584, 184);
            this.ProductList.TabIndex = 0;
            this.ProductList.SelectedIndexChanged += new System.EventHandler(this.ProductList_SelectedIndexChanged);
            // 
            // ProductEditButton
            // 
            this.ProductEditButton.Location = new System.Drawing.Point(658, 215);
            this.ProductEditButton.Name = "ProductEditButton";
            this.ProductEditButton.Size = new System.Drawing.Size(107, 51);
            this.ProductEditButton.TabIndex = 2;
            this.ProductEditButton.Text = "Edit";
            this.ProductEditButton.UseVisualStyleBackColor = true;
            this.ProductEditButton.Click += new System.EventHandler(this.ProductEditButton_Click);
            // 
            // OutOfStockButton
            // 
            this.OutOfStockButton.Location = new System.Drawing.Point(611, 274);
            this.OutOfStockButton.Name = "OutOfStockButton";
            this.OutOfStockButton.Size = new System.Drawing.Size(154, 61);
            this.OutOfStockButton.TabIndex = 3;
            this.OutOfStockButton.Text = "Display out of stock";
            this.OutOfStockButton.UseVisualStyleBackColor = true;
            this.OutOfStockButton.Click += new System.EventHandler(this.OutOfStockButton_Click);
            // 
            // NextRestockButton
            // 
            this.NextRestockButton.Location = new System.Drawing.Point(611, 341);
            this.NextRestockButton.Name = "NextRestockButton";
            this.NextRestockButton.Size = new System.Drawing.Size(154, 68);
            this.NextRestockButton.TabIndex = 4;
            this.NextRestockButton.Text = "Display next restock";
            this.NextRestockButton.UseVisualStyleBackColor = true;
            this.NextRestockButton.Click += new System.EventHandler(this.NextRestockButton_Click);
            // 
            // ProductPricetextbox
            // 
            this.ProductPricetextbox.Location = new System.Drawing.Point(188, 225);
            this.ProductPricetextbox.Name = "ProductPricetextbox";
            this.ProductPricetextbox.PlaceholderText = "Price";
            this.ProductPricetextbox.Size = new System.Drawing.Size(90, 27);
            this.ProductPricetextbox.TabIndex = 7;
            this.ProductPricetextbox.TextChanged += new System.EventHandler(this.ProductPriceTextbox_TextChanged);
            // 
            // ProductStocktextBox
            // 
            this.ProductStocktextBox.Location = new System.Drawing.Point(284, 225);
            this.ProductStocktextBox.Name = "ProductStocktextBox";
            this.ProductStocktextBox.PlaceholderText = "Product Stock";
            this.ProductStocktextBox.Size = new System.Drawing.Size(96, 27);
            this.ProductStocktextBox.TabIndex = 8;
            this.ProductStocktextBox.TextChanged += new System.EventHandler(this.ProductStocktextBox_TextChanged);
            // 
            // ProductDisplayList
            // 
            this.ProductDisplayList.FormattingEnabled = true;
            this.ProductDisplayList.ItemHeight = 20;
            this.ProductDisplayList.Location = new System.Drawing.Point(21, 274);
            this.ProductDisplayList.Name = "ProductDisplayList";
            this.ProductDisplayList.Size = new System.Drawing.Size(579, 144);
            this.ProductDisplayList.TabIndex = 10;
            this.ProductDisplayList.SelectedIndexChanged += new System.EventHandler(this.ProductDisplayList_SelectedIndexChanged);
            // 
            // CustomerPageP
            // 
            this.CustomerPageP.AutoSize = true;
            this.CustomerPageP.Location = new System.Drawing.Point(647, 89);
            this.CustomerPageP.Name = "CustomerPageP";
            this.CustomerPageP.Size = new System.Drawing.Size(129, 24);
            this.CustomerPageP.TabIndex = 12;
            this.CustomerPageP.TabStop = true;
            this.CustomerPageP.Text = "Customer Page";
            this.CustomerPageP.UseVisualStyleBackColor = true;
            this.CustomerPageP.CheckedChanged += new System.EventHandler(this.CustomerPageP_CheckedChanged);
            // 
            // OrderPageP
            // 
            this.OrderPageP.AutoSize = true;
            this.OrderPageP.Location = new System.Drawing.Point(647, 130);
            this.OrderPageP.Name = "OrderPageP";
            this.OrderPageP.Size = new System.Drawing.Size(104, 24);
            this.OrderPageP.TabIndex = 13;
            this.OrderPageP.TabStop = true;
            this.OrderPageP.Text = "Order Page";
            this.OrderPageP.UseVisualStyleBackColor = true;
            this.OrderPageP.CheckedChanged += new System.EventHandler(this.OrderPageP_CheckedChanged);
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Location = new System.Drawing.Point(647, 18);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(82, 20);
            this.MenuLabel.TabIndex = 14;
            this.MenuLabel.Text = "Page Menu";
            this.MenuLabel.Click += new System.EventHandler(this.MenuLabel_Click);
            // 
            // ProdNametextBox
            // 
            this.ProdNametextBox.Location = new System.Drawing.Point(21, 225);
            this.ProdNametextBox.Name = "ProdNametextBox";
            this.ProdNametextBox.PlaceholderText = "Product Name";
            this.ProdNametextBox.Size = new System.Drawing.Size(161, 27);
            this.ProdNametextBox.TabIndex = 16;
            this.ProdNametextBox.TextChanged += new System.EventHandler(this.ProdNametextBox_TextChanged);
            // 
            // ProNextRestocktextBox
            // 
            this.ProNextRestocktextBox.Location = new System.Drawing.Point(386, 225);
            this.ProNextRestocktextBox.Name = "ProNextRestocktextBox";
            this.ProNextRestocktextBox.PlaceholderText = "Next Restock";
            this.ProNextRestocktextBox.Size = new System.Drawing.Size(151, 27);
            this.ProNextRestocktextBox.TabIndex = 17;
            this.ProNextRestocktextBox.TextChanged += new System.EventHandler(this.ProNextRestocktextBox_TextChanged);
            // 
            // ProductAddButton
            // 
            this.ProductAddButton.Location = new System.Drawing.Point(543, 215);
            this.ProductAddButton.Name = "ProductAddButton";
            this.ProductAddButton.Size = new System.Drawing.Size(109, 51);
            this.ProductAddButton.TabIndex = 18;
            this.ProductAddButton.Text = "Add";
            this.ProductAddButton.UseVisualStyleBackColor = true;
            this.ProductAddButton.Click += new System.EventHandler(this.ProductAddButton_Click);
            // 
            // ProductpageLable
            // 
            this.ProductpageLable.AutoSize = true;
            this.ProductpageLable.Location = new System.Drawing.Point(670, 53);
            this.ProductpageLable.Name = "ProductpageLable";
            this.ProductpageLable.Size = new System.Drawing.Size(143, 20);
            this.ProductpageLable.TabIndex = 19;
            this.ProductpageLable.Text = "Product page (Now)";
            this.ProductpageLable.Click += new System.EventHandler(this.ProductpageLable_Click);
            // 
            // MakeNewOrderPageP
            // 
            this.MakeNewOrderPageP.AutoSize = true;
            this.MakeNewOrderPageP.Location = new System.Drawing.Point(647, 171);
            this.MakeNewOrderPageP.Name = "MakeNewOrderPageP";
            this.MakeNewOrderPageP.Size = new System.Drawing.Size(142, 24);
            this.MakeNewOrderPageP.TabIndex = 20;
            this.MakeNewOrderPageP.TabStop = true;
            this.MakeNewOrderPageP.Text = "Make New Order";
            this.MakeNewOrderPageP.UseVisualStyleBackColor = true;
            this.MakeNewOrderPageP.CheckedChanged += new System.EventHandler(this.MakeNewOrderPageP_CheckedChanged);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.MakeNewOrderPageP);
            this.Controls.Add(this.ProductpageLable);
            this.Controls.Add(this.ProductAddButton);
            this.Controls.Add(this.ProNextRestocktextBox);
            this.Controls.Add(this.ProdNametextBox);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.OrderPageP);
            this.Controls.Add(this.CustomerPageP);
            this.Controls.Add(this.ProductDisplayList);
            this.Controls.Add(this.ProductStocktextBox);
            this.Controls.Add(this.ProductPricetextbox);
            this.Controls.Add(this.NextRestockButton);
            this.Controls.Add(this.OutOfStockButton);
            this.Controls.Add(this.ProductEditButton);
            this.Controls.Add(this.ProductList);
            this.Name = "ProductForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProductList;
        private System.Windows.Forms.Button ProductEditButton;
        private System.Windows.Forms.Button OutOfStockButton;
        private System.Windows.Forms.Button NextRestockButton;
        private System.Windows.Forms.TextBox ProductPricetextbox;
        private System.Windows.Forms.TextBox ProductStocktextBox;
        private System.Windows.Forms.Button ProductAddButton;
        private System.Windows.Forms.TextBox ProNextRestocktextBox;
        private System.Windows.Forms.ListBox ProductDisplayList;
        private System.Windows.Forms.RadioButton CustomerPageP;
        private System.Windows.Forms.RadioButton OrderPageP;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.TextBox ProductStock;
        private System.Windows.Forms.TextBox ProdNametextBox;
        private System.Windows.Forms.Label ProductpageLable;
        private System.Windows.Forms.RadioButton MakeNewOrderPageP;
    }
}

