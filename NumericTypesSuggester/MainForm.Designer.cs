namespace NumericTypesSuggester
{
    partial class MainForm
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
            minValueTextBox = new Label();
            maxValueLabel = new Label();
            minValTextBox = new TextBox();
            maxValueTextBox = new TextBox();
            label3 = new Label();
            integralOnlyCheckBox = new CheckBox();
            suggestedTypeLabel = new Label();
            resultTypeLabel = new Label();
            preciseCheckBox = new CheckBox();
            preciseLabel = new Label();
            SuspendLayout();
            // 
            // minValueTextBox
            // 
            minValueTextBox.AutoSize = true;
            minValueTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            minValueTextBox.Location = new Point(66, 93);
            minValueTextBox.Name = "minValueTextBox";
            minValueTextBox.Size = new Size(156, 41);
            minValueTextBox.TabIndex = 0;
            minValueTextBox.Text = "Min Value:";
            // 
            // maxValueLabel
            // 
            maxValueLabel.AutoSize = true;
            maxValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            maxValueLabel.Location = new Point(66, 149);
            maxValueLabel.Name = "maxValueLabel";
            maxValueLabel.Size = new Size(161, 41);
            maxValueLabel.TabIndex = 1;
            maxValueLabel.Text = "Max Value:";
            // 
            // minValTextBox
            // 
            minValTextBox.Location = new Point(233, 107);
            minValTextBox.Name = "minValTextBox";
            minValTextBox.Size = new Size(471, 27);
            minValTextBox.TabIndex = 2;
            minValTextBox.TextChanged += minValTextBox_TextChanged;
            minValTextBox.KeyPress += minValTextBox_KeyPress;
            // 
            // maxValueTextBox
            // 
            maxValueTextBox.Location = new Point(233, 163);
            maxValueTextBox.Name = "maxValueTextBox";
            maxValueTextBox.Size = new Size(471, 27);
            maxValueTextBox.TabIndex = 3;
            maxValueTextBox.TextChanged += maxValueTextBox_TextChanged;
            maxValueTextBox.KeyPress += maxValueTextBox_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(66, 215);
            label3.Name = "label3";
            label3.Size = new Size(197, 41);
            label3.TabIndex = 4;
            label3.Text = "Integral only?";
            // 
            // integralOnlyCheckBox
            // 
            integralOnlyCheckBox.AutoSize = true;
            integralOnlyCheckBox.Location = new Point(274, 235);
            integralOnlyCheckBox.Name = "integralOnlyCheckBox";
            integralOnlyCheckBox.Size = new Size(18, 17);
            integralOnlyCheckBox.TabIndex = 5;
            integralOnlyCheckBox.UseVisualStyleBackColor = true;
            integralOnlyCheckBox.CheckedChanged += integralOnlyCheckBox_CheckedChanged;
            // 
            // suggestedTypeLabel
            // 
            suggestedTypeLabel.AutoSize = true;
            suggestedTypeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            suggestedTypeLabel.Location = new Point(66, 346);
            suggestedTypeLabel.Name = "suggestedTypeLabel";
            suggestedTypeLabel.Size = new Size(238, 41);
            suggestedTypeLabel.TabIndex = 6;
            suggestedTypeLabel.Text = "Suggested Type:";
            // 
            // resultTypeLabel
            // 
            resultTypeLabel.AutoSize = true;
            resultTypeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            resultTypeLabel.Location = new Point(310, 347);
            resultTypeLabel.Name = "resultTypeLabel";
            resultTypeLabel.Size = new Size(245, 41);
            resultTypeLabel.TabIndex = 7;
            resultTypeLabel.Text = "Not enough data";
            // 
            // preciseCheckBox
            // 
            preciseCheckBox.AutoSize = true;
            preciseCheckBox.Location = new Point(310, 296);
            preciseCheckBox.Name = "preciseCheckBox";
            preciseCheckBox.Size = new Size(18, 17);
            preciseCheckBox.TabIndex = 9;
            preciseCheckBox.UseVisualStyleBackColor = true;
            // 
            // preciseLabel
            // 
            preciseLabel.AutoSize = true;
            preciseLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            preciseLabel.Location = new Point(66, 276);
            preciseLabel.Name = "preciseLabel";
            preciseLabel.Size = new Size(242, 41);
            preciseLabel.TabIndex = 8;
            preciseLabel.Text = "Must be precise?";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(818, 450);
            Controls.Add(preciseCheckBox);
            Controls.Add(preciseLabel);
            Controls.Add(resultTypeLabel);
            Controls.Add(suggestedTypeLabel);
            Controls.Add(integralOnlyCheckBox);
            Controls.Add(label3);
            Controls.Add(maxValueTextBox);
            Controls.Add(minValTextBox);
            Controls.Add(maxValueLabel);
            Controls.Add(minValueTextBox);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label minValueTextBox;
        private Label maxValueLabel;
        private TextBox minValTextBox;
        private TextBox maxValueTextBox;
        private Label label3;
        private CheckBox integralOnlyCheckBox;
        private Label suggestedTypeLabel;
        private Label resultTypeLabel;
        private CheckBox preciseCheckBox;
        private Label preciseLabel;
    }
}
