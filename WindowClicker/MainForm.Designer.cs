namespace WindowClicker
{
	partial class MainForm
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
			this.mouseX = new System.Windows.Forms.Label();
			this.mouseY = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.screenY = new System.Windows.Forms.Label();
			this.screenX = new System.Windows.Forms.Label();
			this.clickScreen = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.iterationClicksLbl = new System.Windows.Forms.Label();
			this.iterationClicksMin = new System.Windows.Forms.TextBox();
			this.iterationClicksMax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.clickRadius = new System.Windows.Forms.TextBox();
			this.screenClickPanel = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.estimatedRemaining = new System.Windows.Forms.Label();
			this.estimatedTime = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.testClickPanel = new System.Windows.Forms.Panel();
			this.iterationCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.waitMax = new System.Windows.Forms.TextBox();
			this.waitMin = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.clickMax = new System.Windows.Forms.TextBox();
			this.clickMin = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.elapsedTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mouseX
			// 
			this.mouseX.AutoSize = true;
			this.mouseX.Location = new System.Drawing.Point(111, 21);
			this.mouseX.Name = "mouseX";
			this.mouseX.Size = new System.Drawing.Size(45, 13);
			this.mouseX.TabIndex = 1;
			this.mouseX.Text = "mouseX";
			// 
			// mouseY
			// 
			this.mouseY.AutoSize = true;
			this.mouseY.Location = new System.Drawing.Point(111, 35);
			this.mouseY.Name = "mouseY";
			this.mouseY.Size = new System.Drawing.Size(45, 13);
			this.mouseY.TabIndex = 2;
			this.mouseY.Text = "mouseY";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mouse Move X:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mouse Move Y:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(205, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Screen Click Y:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(205, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Screen Click X:";
			// 
			// screenY
			// 
			this.screenY.AutoSize = true;
			this.screenY.Location = new System.Drawing.Point(291, 35);
			this.screenY.Name = "screenY";
			this.screenY.Size = new System.Drawing.Size(46, 13);
			this.screenY.TabIndex = 6;
			this.screenY.Text = "screenY";
			// 
			// screenX
			// 
			this.screenX.AutoSize = true;
			this.screenX.Location = new System.Drawing.Point(291, 21);
			this.screenX.Name = "screenX";
			this.screenX.Size = new System.Drawing.Size(46, 13);
			this.screenX.TabIndex = 5;
			this.screenX.Text = "screenX";
			// 
			// clickScreen
			// 
			this.clickScreen.Enabled = false;
			this.clickScreen.Location = new System.Drawing.Point(409, 21);
			this.clickScreen.Name = "clickScreen";
			this.clickScreen.Size = new System.Drawing.Size(103, 27);
			this.clickScreen.TabIndex = 12;
			this.clickScreen.Text = "Click Screen";
			this.clickScreen.UseVisualStyleBackColor = true;
			this.clickScreen.Click += new System.EventHandler(this.clickScreen_Click);
			// 
			// progressBar
			// 
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar.Location = new System.Drawing.Point(0, 270);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(800, 14);
			this.progressBar.TabIndex = 13;
			// 
			// iterationClicksLbl
			// 
			this.iterationClicksLbl.AutoSize = true;
			this.iterationClicksLbl.Location = new System.Drawing.Point(90, 132);
			this.iterationClicksLbl.Name = "iterationClicksLbl";
			this.iterationClicksLbl.Size = new System.Drawing.Size(38, 13);
			this.iterationClicksLbl.TabIndex = 22;
			this.iterationClicksLbl.Text = "Clicks:";
			// 
			// iterationClicksMin
			// 
			this.iterationClicksMin.Location = new System.Drawing.Point(134, 129);
			this.iterationClicksMin.Name = "iterationClicksMin";
			this.iterationClicksMin.Size = new System.Drawing.Size(56, 20);
			this.iterationClicksMin.TabIndex = 2;
			this.iterationClicksMin.Text = "101";
			this.iterationClicksMin.Leave += new System.EventHandler(this.iterationClicksMin_Leave);
			// 
			// iterationClicksMax
			// 
			this.iterationClicksMax.Location = new System.Drawing.Point(198, 129);
			this.iterationClicksMax.Name = "iterationClicksMax";
			this.iterationClicksMax.Size = new System.Drawing.Size(56, 20);
			this.iterationClicksMax.TabIndex = 3;
			this.iterationClicksMax.Text = "111";
			this.iterationClicksMax.Leave += new System.EventHandler(this.iterationClicksMin_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(216, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Click Radius:";
			// 
			// clickRadius
			// 
			this.clickRadius.Location = new System.Drawing.Point(291, 54);
			this.clickRadius.Name = "clickRadius";
			this.clickRadius.Size = new System.Drawing.Size(56, 20);
			this.clickRadius.TabIndex = 1;
			this.clickRadius.Text = "10";
			// 
			// screenClickPanel
			// 
			this.screenClickPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.screenClickPanel.Location = new System.Drawing.Point(528, 22);
			this.screenClickPanel.Name = "screenClickPanel";
			this.screenClickPanel.Size = new System.Drawing.Size(252, 228);
			this.screenClickPanel.TabIndex = 27;
			this.screenClickPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screenClickPanel_MouseClick);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(15, 237);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(109, 13);
			this.label10.TabIndex = 31;
			this.label10.Text = "Estimated Remaining:";
			// 
			// estimatedRemaining
			// 
			this.estimatedRemaining.AutoSize = true;
			this.estimatedRemaining.Location = new System.Drawing.Point(131, 237);
			this.estimatedRemaining.Name = "estimatedRemaining";
			this.estimatedRemaining.Size = new System.Drawing.Size(102, 13);
			this.estimatedRemaining.TabIndex = 44;
			this.estimatedRemaining.Text = "estimatedRemaining";
			// 
			// estimatedTime
			// 
			this.estimatedTime.AutoSize = true;
			this.estimatedTime.Location = new System.Drawing.Point(131, 190);
			this.estimatedTime.Name = "estimatedTime";
			this.estimatedTime.Size = new System.Drawing.Size(75, 13);
			this.estimatedTime.TabIndex = 43;
			this.estimatedTime.Text = "estimatedTime";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(42, 190);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 13);
			this.label9.TabIndex = 42;
			this.label9.Text = "Estimated Time:";
			// 
			// testClickPanel
			// 
			this.testClickPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.testClickPanel.Location = new System.Drawing.Point(327, 148);
			this.testClickPanel.Name = "testClickPanel";
			this.testClickPanel.Size = new System.Drawing.Size(117, 80);
			this.testClickPanel.TabIndex = 41;
			// 
			// iterationCount
			// 
			this.iterationCount.Location = new System.Drawing.Point(86, 94);
			this.iterationCount.Name = "iterationCount";
			this.iterationCount.Size = new System.Drawing.Size(56, 20);
			this.iterationCount.TabIndex = 33;
			this.iterationCount.Text = "30";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(27, 94);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 40;
			this.label8.Text = "Iterations:";
			// 
			// waitMax
			// 
			this.waitMax.Location = new System.Drawing.Point(301, 94);
			this.waitMax.Name = "waitMax";
			this.waitMax.Size = new System.Drawing.Size(56, 20);
			this.waitMax.TabIndex = 37;
			this.waitMax.Text = "750";
			// 
			// waitMin
			// 
			this.waitMin.Location = new System.Drawing.Point(239, 94);
			this.waitMin.Name = "waitMin";
			this.waitMin.Size = new System.Drawing.Size(56, 20);
			this.waitMin.TabIndex = 36;
			this.waitMin.Text = "500";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(166, 97);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 39;
			this.label7.Text = "Wait Range:";
			// 
			// clickMax
			// 
			this.clickMax.Location = new System.Drawing.Point(198, 155);
			this.clickMax.Name = "clickMax";
			this.clickMax.Size = new System.Drawing.Size(56, 20);
			this.clickMax.TabIndex = 35;
			this.clickMax.Text = "100";
			// 
			// clickMin
			// 
			this.clickMin.Location = new System.Drawing.Point(134, 155);
			this.clickMin.Name = "clickMin";
			this.clickMin.Size = new System.Drawing.Size(56, 20);
			this.clickMin.TabIndex = 34;
			this.clickMin.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(60, 158);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 13);
			this.label6.TabIndex = 38;
			this.label6.Text = "Click Range:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(50, 215);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(74, 13);
			this.label11.TabIndex = 45;
			this.label11.Text = "Elapsed Time:";
			// 
			// elapsedTime
			// 
			this.elapsedTime.AutoSize = true;
			this.elapsedTime.Location = new System.Drawing.Point(131, 215);
			this.elapsedTime.Name = "elapsedTime";
			this.elapsedTime.Size = new System.Drawing.Size(52, 13);
			this.elapsedTime.TabIndex = 46;
			this.elapsedTime.Text = "0:00:0.00";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 284);
			this.Controls.Add(this.elapsedTime);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.estimatedRemaining);
			this.Controls.Add(this.estimatedTime);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.testClickPanel);
			this.Controls.Add(this.iterationCount);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.waitMax);
			this.Controls.Add(this.waitMin);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.clickMax);
			this.Controls.Add(this.clickMin);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.screenClickPanel);
			this.Controls.Add(this.clickRadius);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.iterationClicksMax);
			this.Controls.Add(this.iterationClicksMin);
			this.Controls.Add(this.iterationClicksLbl);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.clickScreen);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.screenY);
			this.Controls.Add(this.screenX);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.mouseY);
			this.Controls.Add(this.mouseX);
			this.Name = "MainForm";
			this.Opacity = 0.8D;
			this.Text = "Window Clicker";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label mouseX;
		private System.Windows.Forms.Label mouseY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label screenY;
		private System.Windows.Forms.Label screenX;
		private System.Windows.Forms.Button clickScreen;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label iterationClicksLbl;
		private System.Windows.Forms.TextBox iterationClicksMin;
		private System.Windows.Forms.TextBox iterationClicksMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox clickRadius;
		private System.Windows.Forms.Panel screenClickPanel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label estimatedRemaining;
		private System.Windows.Forms.Label estimatedTime;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel testClickPanel;
		private System.Windows.Forms.TextBox iterationCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox waitMax;
		private System.Windows.Forms.TextBox waitMin;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox clickMax;
		private System.Windows.Forms.TextBox clickMin;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label elapsedTime;
	}
}