namespace AllocationForm
{
    partial class Allocation
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
            this.loadAllocationFileButton = new System.Windows.Forms.Button();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.styleLookupPathTextBox = new System.Windows.Forms.TextBox();
            this.loadStyleLookupSheetButton = new System.Windows.Forms.Button();
            this.runApp = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.allocationFileLabel = new System.Windows.Forms.Label();
            this.styleLookupFileLabel = new System.Windows.Forms.Label();
            this.selectOutputFolderButton = new System.Windows.Forms.Button();
            this.outputFileNameLabel = new System.Windows.Forms.Label();
            this.outputFileNameTextBox = new System.Windows.Forms.TextBox();
            this.csvLabel = new System.Windows.Forms.Label();
            this.storeSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.differentBrandRadioButton = new System.Windows.Forms.RadioButton();
            this.brandRadioButton = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.styleMasterFileLabel = new System.Windows.Forms.Label();
            this.styleMasterPathTextBox = new System.Windows.Forms.TextBox();
            this.loadStyleMasterSheetButton = new System.Windows.Forms.Button();
            this.storeSelectGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadAllocationFileButton
            // 
            this.loadAllocationFileButton.Location = new System.Drawing.Point(375, 9);
            this.loadAllocationFileButton.Name = "loadAllocationFileButton";
            this.loadAllocationFileButton.Size = new System.Drawing.Size(91, 23);
            this.loadAllocationFileButton.TabIndex = 1;
            this.loadAllocationFileButton.Text = "Allocation File";
            this.loadAllocationFileButton.UseVisualStyleBackColor = true;
            this.loadAllocationFileButton.Click += new System.EventHandler(this.loadAllocationFileButton_Click);
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Location = new System.Drawing.Point(136, 12);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(233, 20);
            this.sourcePathTextBox.TabIndex = 2;
            // 
            // styleLookupPathTextBox
            // 
            this.styleLookupPathTextBox.Location = new System.Drawing.Point(136, 45);
            this.styleLookupPathTextBox.Name = "styleLookupPathTextBox";
            this.styleLookupPathTextBox.Size = new System.Drawing.Size(233, 20);
            this.styleLookupPathTextBox.TabIndex = 3;
            // 
            // loadStyleLookupSheetButton
            // 
            this.loadStyleLookupSheetButton.Location = new System.Drawing.Point(375, 42);
            this.loadStyleLookupSheetButton.Name = "loadStyleLookupSheetButton";
            this.loadStyleLookupSheetButton.Size = new System.Drawing.Size(91, 23);
            this.loadStyleLookupSheetButton.TabIndex = 4;
            this.loadStyleLookupSheetButton.Text = "Style Selling";
            this.loadStyleLookupSheetButton.UseVisualStyleBackColor = true;
            this.loadStyleLookupSheetButton.Click += new System.EventHandler(this.loadLookupSheetButton_Click);
            // 
            // runApp
            // 
            this.runApp.Location = new System.Drawing.Point(185, 239);
            this.runApp.Name = "runApp";
            this.runApp.Size = new System.Drawing.Size(112, 30);
            this.runApp.TabIndex = 5;
            this.runApp.Text = "Run!";
            this.runApp.UseVisualStyleBackColor = true;
            this.runApp.Click += new System.EventHandler(this.runApp_Click);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(136, 182);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(233, 20);
            this.outputPathTextBox.TabIndex = 6;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(28, 185);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(109, 13);
            this.outputLabel.TabIndex = 7;
            this.outputLabel.Text = "Output File Directory: ";
            // 
            // allocationFileLabel
            // 
            this.allocationFileLabel.AutoSize = true;
            this.allocationFileLabel.Location = new System.Drawing.Point(12, 15);
            this.allocationFileLabel.Name = "allocationFileLabel";
            this.allocationFileLabel.Size = new System.Drawing.Size(122, 13);
            this.allocationFileLabel.TabIndex = 8;
            this.allocationFileLabel.Text = "Allocation File Location: ";
            // 
            // styleLookupFileLabel
            // 
            this.styleLookupFileLabel.AutoSize = true;
            this.styleLookupFileLabel.Location = new System.Drawing.Point(22, 48);
            this.styleLookupFileLabel.Name = "styleLookupFileLabel";
            this.styleLookupFileLabel.Size = new System.Drawing.Size(114, 13);
            this.styleLookupFileLabel.TabIndex = 9;
            this.styleLookupFileLabel.Text = "Style Selling Location: ";
            // 
            // selectOutputFolderButton
            // 
            this.selectOutputFolderButton.Location = new System.Drawing.Point(374, 179);
            this.selectOutputFolderButton.Name = "selectOutputFolderButton";
            this.selectOutputFolderButton.Size = new System.Drawing.Size(91, 23);
            this.selectOutputFolderButton.TabIndex = 10;
            this.selectOutputFolderButton.Text = "Output Location";
            this.selectOutputFolderButton.UseVisualStyleBackColor = true;
            this.selectOutputFolderButton.Click += new System.EventHandler(this.selectOutputFolderButton_Click);
            // 
            // outputFileNameLabel
            // 
            this.outputFileNameLabel.AutoSize = true;
            this.outputFileNameLabel.Location = new System.Drawing.Point(133, 216);
            this.outputFileNameLabel.Name = "outputFileNameLabel";
            this.outputFileNameLabel.Size = new System.Drawing.Size(95, 13);
            this.outputFileNameLabel.TabIndex = 11;
            this.outputFileNameLabel.Text = "Output File Name: ";
            // 
            // outputFileNameTextBox
            // 
            this.outputFileNameTextBox.Location = new System.Drawing.Point(234, 213);
            this.outputFileNameTextBox.Name = "outputFileNameTextBox";
            this.outputFileNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.outputFileNameTextBox.TabIndex = 12;
            // 
            // csvLabel
            // 
            this.csvLabel.AutoSize = true;
            this.csvLabel.Location = new System.Drawing.Point(367, 216);
            this.csvLabel.Name = "csvLabel";
            this.csvLabel.Size = new System.Drawing.Size(27, 13);
            this.csvLabel.TabIndex = 13;
            this.csvLabel.Text = ".csv";
            // 
            // storeSelectGroupBox
            // 
            this.storeSelectGroupBox.Controls.Add(this.differentBrandRadioButton);
            this.storeSelectGroupBox.Controls.Add(this.brandRadioButton);
            this.storeSelectGroupBox.Location = new System.Drawing.Point(25, 206);
            this.storeSelectGroupBox.Name = "storeSelectGroupBox";
            this.storeSelectGroupBox.Size = new System.Drawing.Size(94, 61);
            this.storeSelectGroupBox.TabIndex = 14;
            this.storeSelectGroupBox.TabStop = false;
            this.storeSelectGroupBox.Text = "Store";
            // 
            // differentBrandRadioButton
            // 
            this.differentBrandRadioButton.AutoSize = true;
            this.differentBrandRadioButton.Location = new System.Drawing.Point(10, 38);
            this.differentBrandRadioButton.Name = "differentBrandRadioButton";
            this.differentBrandRadioButton.Size = new System.Drawing.Size(82, 17);
            this.differentBrandRadioButton.TabIndex = 1;
            this.differentBrandRadioButton.TabStop = true;
            this.differentBrandRadioButton.Text = "Other Brand";
            this.differentBrandRadioButton.UseVisualStyleBackColor = true;
            // 
            // brandRadioButton
            // 
            this.brandRadioButton.AutoSize = true;
            this.brandRadioButton.Location = new System.Drawing.Point(10, 15);
            this.brandRadioButton.Name = "brandRadioButton";
            this.brandRadioButton.Size = new System.Drawing.Size(75, 17);
            this.brandRadioButton.TabIndex = 0;
            this.brandRadioButton.TabStop = true;
            this.brandRadioButton.Text = "First Brand";
            this.brandRadioButton.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 275);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 18);
            this.progressBar.TabIndex = 15;
            // 
            // styleMasterFileLabel
            // 
            this.styleMasterFileLabel.AutoSize = true;
            this.styleMasterFileLabel.Location = new System.Drawing.Point(22, 82);
            this.styleMasterFileLabel.Name = "styleMasterFileLabel";
            this.styleMasterFileLabel.Size = new System.Drawing.Size(115, 13);
            this.styleMasterFileLabel.TabIndex = 16;
            this.styleMasterFileLabel.Text = "Style Master Location: ";
            // 
            // styleMasterPathTextBox
            // 
            this.styleMasterPathTextBox.Location = new System.Drawing.Point(136, 79);
            this.styleMasterPathTextBox.Name = "styleMasterPathTextBox";
            this.styleMasterPathTextBox.Size = new System.Drawing.Size(233, 20);
            this.styleMasterPathTextBox.TabIndex = 17;
            // 
            // loadStyleMasterSheetButton
            // 
            this.loadStyleMasterSheetButton.Location = new System.Drawing.Point(374, 77);
            this.loadStyleMasterSheetButton.Name = "loadStyleMasterSheetButton";
            this.loadStyleMasterSheetButton.Size = new System.Drawing.Size(91, 23);
            this.loadStyleMasterSheetButton.TabIndex = 18;
            this.loadStyleMasterSheetButton.Text = "Style Master";
            this.loadStyleMasterSheetButton.UseVisualStyleBackColor = true;
            this.loadStyleMasterSheetButton.Click += new System.EventHandler(this.loadStyleMasterSheetButton_Click);
            // 
            // Allocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 305);
            this.Controls.Add(this.loadStyleMasterSheetButton);
            this.Controls.Add(this.styleMasterPathTextBox);
            this.Controls.Add(this.styleMasterFileLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.storeSelectGroupBox);
            this.Controls.Add(this.csvLabel);
            this.Controls.Add(this.outputFileNameTextBox);
            this.Controls.Add(this.outputFileNameLabel);
            this.Controls.Add(this.selectOutputFolderButton);
            this.Controls.Add(this.styleLookupFileLabel);
            this.Controls.Add(this.allocationFileLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.runApp);
            this.Controls.Add(this.loadStyleLookupSheetButton);
            this.Controls.Add(this.styleLookupPathTextBox);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.loadAllocationFileButton);
            this.Name = "Allocation";
            this.Text = "Allocation Program";
            this.storeSelectGroupBox.ResumeLayout(false);
            this.storeSelectGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadAllocationFileButton;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.TextBox styleLookupPathTextBox;
        private System.Windows.Forms.Button loadStyleLookupSheetButton;
        private System.Windows.Forms.Button runApp;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label allocationFileLabel;
        private System.Windows.Forms.Label styleLookupFileLabel;
        private System.Windows.Forms.Button selectOutputFolderButton;
        private System.Windows.Forms.Label outputFileNameLabel;
        private System.Windows.Forms.TextBox outputFileNameTextBox;
        private System.Windows.Forms.Label csvLabel;
        private System.Windows.Forms.GroupBox storeSelectGroupBox;
        private System.Windows.Forms.RadioButton differentBrandRadioButton;
        private System.Windows.Forms.RadioButton brandRadioButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label styleMasterFileLabel;
        private System.Windows.Forms.TextBox styleMasterPathTextBox;
        private System.Windows.Forms.Button loadStyleMasterSheetButton;
    }
}

