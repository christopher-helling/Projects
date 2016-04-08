namespace InventoryManagementForm
{
    partial class InventoryManagement
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
            this.loadStyleSellingFileButton = new System.Windows.Forms.Button();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.inventoryLookupPathTextBox = new System.Windows.Forms.TextBox();
            this.loadInventoryLookupSheetButton = new System.Windows.Forms.Button();
            this.runApp = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.styleSellingFileLabel = new System.Windows.Forms.Label();
            this.inventoryLookupFileLabel = new System.Windows.Forms.Label();
            this.selectOutputFolderButton = new System.Windows.Forms.Button();
            this.outputStylesFileNameLabel = new System.Windows.Forms.Label();
            this.outputStyleFileNameTextBox = new System.Windows.Forms.TextBox();
            this.csvLabel1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.csvLabel2 = new System.Windows.Forms.Label();
            this.outputInventoryFileNameTextBox = new System.Windows.Forms.TextBox();
            this.outputInventoryFileNameLabel = new System.Windows.Forms.Label();
            this.minSTPercentageTextBox = new System.Windows.Forms.TextBox();
            this.minSTPercentageLabel = new System.Windows.Forms.Label();
            this.transferBudgetLabel = new System.Windows.Forms.Label();
            this.transferBudgetTextBox = new System.Windows.Forms.TextBox();
            this.minNumOHUnitsLabel = new System.Windows.Forms.Label();
            this.minNumOHUnitsTextBox = new System.Windows.Forms.TextBox();
            this.seasonCodeLabel1 = new System.Windows.Forms.Label();
            this.seasonCodeTextBox = new System.Windows.Forms.TextBox();
            this.seasonCodeLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadStyleSellingFileButton
            // 
            this.loadStyleSellingFileButton.Location = new System.Drawing.Point(385, 9);
            this.loadStyleSellingFileButton.Name = "loadStyleSellingFileButton";
            this.loadStyleSellingFileButton.Size = new System.Drawing.Size(91, 23);
            this.loadStyleSellingFileButton.TabIndex = 1;
            this.loadStyleSellingFileButton.Text = "Style Selling";
            this.loadStyleSellingFileButton.UseVisualStyleBackColor = true;
            this.loadStyleSellingFileButton.Click += new System.EventHandler(this.loadStyleSellingFileButton_Click);
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Location = new System.Drawing.Point(146, 11);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(233, 20);
            this.sourcePathTextBox.TabIndex = 2;
            // 
            // inventoryLookupPathTextBox
            // 
            this.inventoryLookupPathTextBox.Location = new System.Drawing.Point(146, 45);
            this.inventoryLookupPathTextBox.Name = "inventoryLookupPathTextBox";
            this.inventoryLookupPathTextBox.Size = new System.Drawing.Size(233, 20);
            this.inventoryLookupPathTextBox.TabIndex = 3;
            // 
            // loadInventoryLookupSheetButton
            // 
            this.loadInventoryLookupSheetButton.Location = new System.Drawing.Point(385, 42);
            this.loadInventoryLookupSheetButton.Name = "loadInventoryLookupSheetButton";
            this.loadInventoryLookupSheetButton.Size = new System.Drawing.Size(91, 23);
            this.loadInventoryLookupSheetButton.TabIndex = 4;
            this.loadInventoryLookupSheetButton.Text = "Inventory";
            this.loadInventoryLookupSheetButton.UseVisualStyleBackColor = true;
            this.loadInventoryLookupSheetButton.Click += new System.EventHandler(this.loadInventoryLookupSheetButton_Click);
            // 
            // runApp
            // 
            this.runApp.Location = new System.Drawing.Point(189, 315);
            this.runApp.Name = "runApp";
            this.runApp.Size = new System.Drawing.Size(112, 30);
            this.runApp.TabIndex = 5;
            this.runApp.Text = "Run!";
            this.runApp.UseVisualStyleBackColor = true;
            this.runApp.Click += new System.EventHandler(this.runApp_Click);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(146, 228);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(233, 20);
            this.outputPathTextBox.TabIndex = 6;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(37, 231);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(109, 13);
            this.outputLabel.TabIndex = 7;
            this.outputLabel.Text = "Output File Directory: ";
            // 
            // styleSellingFileLabel
            // 
            this.styleSellingFileLabel.AutoSize = true;
            this.styleSellingFileLabel.Location = new System.Drawing.Point(29, 14);
            this.styleSellingFileLabel.Name = "styleSellingFileLabel";
            this.styleSellingFileLabel.Size = new System.Drawing.Size(111, 13);
            this.styleSellingFileLabel.TabIndex = 8;
            this.styleSellingFileLabel.Text = "Style Selling Location:";
            // 
            // inventoryLookupFileLabel
            // 
            this.inventoryLookupFileLabel.AutoSize = true;
            this.inventoryLookupFileLabel.Location = new System.Drawing.Point(26, 48);
            this.inventoryLookupFileLabel.Name = "inventoryLookupFileLabel";
            this.inventoryLookupFileLabel.Size = new System.Drawing.Size(120, 13);
            this.inventoryLookupFileLabel.TabIndex = 9;
            this.inventoryLookupFileLabel.Text = "Inventory File Location: ";
            // 
            // selectOutputFolderButton
            // 
            this.selectOutputFolderButton.Location = new System.Drawing.Point(385, 226);
            this.selectOutputFolderButton.Name = "selectOutputFolderButton";
            this.selectOutputFolderButton.Size = new System.Drawing.Size(91, 23);
            this.selectOutputFolderButton.TabIndex = 10;
            this.selectOutputFolderButton.Text = "Output Location";
            this.selectOutputFolderButton.UseVisualStyleBackColor = true;
            this.selectOutputFolderButton.Click += new System.EventHandler(this.selectOutputFolderButton_Click);
            // 
            // outputStylesFileNameLabel
            // 
            this.outputStylesFileNameLabel.AutoSize = true;
            this.outputStylesFileNameLabel.Location = new System.Drawing.Point(20, 266);
            this.outputStylesFileNameLabel.Name = "outputStylesFileNameLabel";
            this.outputStylesFileNameLabel.Size = new System.Drawing.Size(126, 13);
            this.outputStylesFileNameLabel.TabIndex = 11;
            this.outputStylesFileNameLabel.Text = "Output Styles File Name: ";
            // 
            // outputStyleFileNameTextBox
            // 
            this.outputStyleFileNameTextBox.Location = new System.Drawing.Point(146, 263);
            this.outputStyleFileNameTextBox.Name = "outputStyleFileNameTextBox";
            this.outputStyleFileNameTextBox.Size = new System.Drawing.Size(202, 20);
            this.outputStyleFileNameTextBox.TabIndex = 12;
            // 
            // csvLabel1
            // 
            this.csvLabel1.AutoSize = true;
            this.csvLabel1.Location = new System.Drawing.Point(352, 266);
            this.csvLabel1.Name = "csvLabel1";
            this.csvLabel1.Size = new System.Drawing.Size(27, 13);
            this.csvLabel1.TabIndex = 13;
            this.csvLabel1.Text = ".csv";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 351);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(461, 18);
            this.progressBar.TabIndex = 15;
            // 
            // csvLabel2
            // 
            this.csvLabel2.AutoSize = true;
            this.csvLabel2.Location = new System.Drawing.Point(352, 292);
            this.csvLabel2.Name = "csvLabel2";
            this.csvLabel2.Size = new System.Drawing.Size(27, 13);
            this.csvLabel2.TabIndex = 18;
            this.csvLabel2.Text = ".csv";
            // 
            // outputInventoryFileNameTextBox
            // 
            this.outputInventoryFileNameTextBox.Location = new System.Drawing.Point(146, 289);
            this.outputInventoryFileNameTextBox.Name = "outputInventoryFileNameTextBox";
            this.outputInventoryFileNameTextBox.Size = new System.Drawing.Size(202, 20);
            this.outputInventoryFileNameTextBox.TabIndex = 17;
            // 
            // outputInventoryFileNameLabel
            // 
            this.outputInventoryFileNameLabel.AutoSize = true;
            this.outputInventoryFileNameLabel.Location = new System.Drawing.Point(4, 292);
            this.outputInventoryFileNameLabel.Name = "outputInventoryFileNameLabel";
            this.outputInventoryFileNameLabel.Size = new System.Drawing.Size(142, 13);
            this.outputInventoryFileNameLabel.TabIndex = 16;
            this.outputInventoryFileNameLabel.Text = "Output Inventory File Name: ";
            // 
            // minSTPercentageTextBox
            // 
            this.minSTPercentageTextBox.Location = new System.Drawing.Point(274, 80);
            this.minSTPercentageTextBox.Name = "minSTPercentageTextBox";
            this.minSTPercentageTextBox.Size = new System.Drawing.Size(105, 20);
            this.minSTPercentageTextBox.TabIndex = 19;
            // 
            // minSTPercentageLabel
            // 
            this.minSTPercentageLabel.AutoSize = true;
            this.minSTPercentageLabel.Location = new System.Drawing.Point(157, 83);
            this.minSTPercentageLabel.Name = "minSTPercentageLabel";
            this.minSTPercentageLabel.Size = new System.Drawing.Size(111, 13);
            this.minSTPercentageLabel.TabIndex = 20;
            this.minSTPercentageLabel.Text = "Enter minimum S/T %:";
            // 
            // transferBudgetLabel
            // 
            this.transferBudgetLabel.AutoSize = true;
            this.transferBudgetLabel.Location = new System.Drawing.Point(150, 109);
            this.transferBudgetLabel.Name = "transferBudgetLabel";
            this.transferBudgetLabel.Size = new System.Drawing.Size(118, 13);
            this.transferBudgetLabel.TabIndex = 22;
            this.transferBudgetLabel.Text = "Enter transfer budget: $";
            // 
            // transferBudgetTextBox
            // 
            this.transferBudgetTextBox.Location = new System.Drawing.Point(274, 106);
            this.transferBudgetTextBox.Name = "transferBudgetTextBox";
            this.transferBudgetTextBox.Size = new System.Drawing.Size(105, 20);
            this.transferBudgetTextBox.TabIndex = 21;
            // 
            // minNumOHUnitsLabel
            // 
            this.minNumOHUnitsLabel.AutoSize = true;
            this.minNumOHUnitsLabel.Location = new System.Drawing.Point(96, 135);
            this.minNumOHUnitsLabel.Name = "minNumOHUnitsLabel";
            this.minNumOHUnitsLabel.Size = new System.Drawing.Size(172, 13);
            this.minNumOHUnitsLabel.TabIndex = 24;
            this.minNumOHUnitsLabel.Text = "Enter minimum number of OH units:";
            // 
            // minNumOHUnitsTextBox
            // 
            this.minNumOHUnitsTextBox.Location = new System.Drawing.Point(274, 132);
            this.minNumOHUnitsTextBox.Name = "minNumOHUnitsTextBox";
            this.minNumOHUnitsTextBox.Size = new System.Drawing.Size(105, 20);
            this.minNumOHUnitsTextBox.TabIndex = 23;
            // 
            // seasonCodeLabel1
            // 
            this.seasonCodeLabel1.AutoSize = true;
            this.seasonCodeLabel1.Location = new System.Drawing.Point(112, 161);
            this.seasonCodeLabel1.Name = "seasonCodeLabel1";
            this.seasonCodeLabel1.Size = new System.Drawing.Size(156, 13);
            this.seasonCodeLabel1.TabIndex = 26;
            this.seasonCodeLabel1.Text = "Enter season codes to include: ";
            // 
            // seasonCodeTextBox
            // 
            this.seasonCodeTextBox.Location = new System.Drawing.Point(274, 167);
            this.seasonCodeTextBox.Name = "seasonCodeTextBox";
            this.seasonCodeTextBox.Size = new System.Drawing.Size(105, 20);
            this.seasonCodeTextBox.TabIndex = 25;
            // 
            // seasonCodeLabel2
            // 
            this.seasonCodeLabel2.AutoSize = true;
            this.seasonCodeLabel2.Location = new System.Drawing.Point(125, 174);
            this.seasonCodeLabel2.Name = "seasonCodeLabel2";
            this.seasonCodeLabel2.Size = new System.Drawing.Size(129, 13);
            this.seasonCodeLabel2.TabIndex = 27;
            this.seasonCodeLabel2.Text = "(separated by semicolons)";
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 390);
            this.Controls.Add(this.seasonCodeLabel2);
            this.Controls.Add(this.seasonCodeLabel1);
            this.Controls.Add(this.seasonCodeTextBox);
            this.Controls.Add(this.minNumOHUnitsLabel);
            this.Controls.Add(this.minNumOHUnitsTextBox);
            this.Controls.Add(this.transferBudgetLabel);
            this.Controls.Add(this.transferBudgetTextBox);
            this.Controls.Add(this.minSTPercentageLabel);
            this.Controls.Add(this.minSTPercentageTextBox);
            this.Controls.Add(this.csvLabel2);
            this.Controls.Add(this.outputInventoryFileNameTextBox);
            this.Controls.Add(this.outputInventoryFileNameLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.csvLabel1);
            this.Controls.Add(this.outputStyleFileNameTextBox);
            this.Controls.Add(this.outputStylesFileNameLabel);
            this.Controls.Add(this.selectOutputFolderButton);
            this.Controls.Add(this.inventoryLookupFileLabel);
            this.Controls.Add(this.styleSellingFileLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.runApp);
            this.Controls.Add(this.loadInventoryLookupSheetButton);
            this.Controls.Add(this.inventoryLookupPathTextBox);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.loadStyleSellingFileButton);
            this.Name = "InventoryManagement";
            this.Text = "Inventory Management Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadStyleSellingFileButton;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.TextBox inventoryLookupPathTextBox;
        private System.Windows.Forms.Button loadInventoryLookupSheetButton;
        private System.Windows.Forms.Button runApp;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label styleSellingFileLabel;
        private System.Windows.Forms.Label inventoryLookupFileLabel;
        private System.Windows.Forms.Button selectOutputFolderButton;
        private System.Windows.Forms.Label outputStylesFileNameLabel;
        private System.Windows.Forms.TextBox outputStyleFileNameTextBox;
        private System.Windows.Forms.Label csvLabel1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label csvLabel2;
        private System.Windows.Forms.TextBox outputInventoryFileNameTextBox;
        private System.Windows.Forms.Label outputInventoryFileNameLabel;
        private System.Windows.Forms.TextBox minSTPercentageTextBox;
        private System.Windows.Forms.Label minSTPercentageLabel;
        private System.Windows.Forms.Label transferBudgetLabel;
        private System.Windows.Forms.TextBox transferBudgetTextBox;
        private System.Windows.Forms.Label minNumOHUnitsLabel;
        private System.Windows.Forms.TextBox minNumOHUnitsTextBox;
        private System.Windows.Forms.Label seasonCodeLabel1;
        private System.Windows.Forms.TextBox seasonCodeTextBox;
        private System.Windows.Forms.Label seasonCodeLabel2;
    }
}

