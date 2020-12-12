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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.screenY = new System.Windows.Forms.Label();
			this.screenX = new System.Windows.Forms.Label();
			this.cClickScreen = new System.Windows.Forms.Button();
			this.iterationClicksLbl = new System.Windows.Forms.Label();
			this.iterationClicksMin = new System.Windows.Forms.TextBox();
			this.iterationClicksMax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cClickRadius = new System.Windows.Forms.TextBox();
			this.screenClickPanel = new System.Windows.Forms.Panel();
			this.cSavePosition = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.estimatedRemaining = new System.Windows.Forms.Label();
			this.estimatedTime = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cIterationCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cWaitMax = new System.Windows.Forms.TextBox();
			this.cWaitMin = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.clickMax = new System.Windows.Forms.TextBox();
			this.clickMin = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.elapsedTime = new System.Windows.Forms.Label();
			this.cClickDetail = new System.Windows.Forms.Label();
			this.cIterationClicksDetail = new System.Windows.Forms.Label();
			this.waiting = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.totalClicks = new System.Windows.Forms.Label();
			this.cAddAction = new System.Windows.Forms.Button();
			this.cActionList = new System.Windows.Forms.ListBox();
			this.cUseActions = new System.Windows.Forms.CheckBox();
			this.cUpdateAction = new System.Windows.Forms.Button();
			this.cMainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.cOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.cDeleteAction = new System.Windows.Forms.Button();
			this.cActionCount = new System.Windows.Forms.Label();
			this.cSkipAction = new System.Windows.Forms.Button();
			this.cStatusStrip = new System.Windows.Forms.StatusStrip();
			this.cStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.cProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.currentLabel = new System.Windows.Forms.Label();
			this.currentIteration = new System.Windows.Forms.Label();
			this.screenClickPanel.SuspendLayout();
			this.cMainMenu.SuspendLayout();
			this.cStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Screen Click Y:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Screen Click X:";
			// 
			// screenY
			// 
			this.screenY.AutoSize = true;
			this.screenY.Location = new System.Drawing.Point(89, 19);
			this.screenY.Name = "screenY";
			this.screenY.Size = new System.Drawing.Size(46, 13);
			this.screenY.TabIndex = 6;
			this.screenY.Text = "screenY";
			// 
			// screenX
			// 
			this.screenX.AutoSize = true;
			this.screenX.Location = new System.Drawing.Point(89, 5);
			this.screenX.Name = "screenX";
			this.screenX.Size = new System.Drawing.Size(46, 13);
			this.screenX.TabIndex = 5;
			this.screenX.Text = "screenX";
			// 
			// cClickScreen
			// 
			this.cClickScreen.Enabled = false;
			this.cClickScreen.Location = new System.Drawing.Point(423, 304);
			this.cClickScreen.Name = "cClickScreen";
			this.cClickScreen.Size = new System.Drawing.Size(119, 27);
			this.cClickScreen.TabIndex = 12;
			this.cClickScreen.Text = "Click Screen";
			this.cClickScreen.UseVisualStyleBackColor = true;
			this.cClickScreen.Click += new System.EventHandler(this.cClickScreen_Click);
			// 
			// iterationClicksLbl
			// 
			this.iterationClicksLbl.AutoSize = true;
			this.iterationClicksLbl.Location = new System.Drawing.Point(61, 95);
			this.iterationClicksLbl.Name = "iterationClicksLbl";
			this.iterationClicksLbl.Size = new System.Drawing.Size(38, 13);
			this.iterationClicksLbl.TabIndex = 22;
			this.iterationClicksLbl.Text = "Clicks:";
			// 
			// iterationClicksMin
			// 
			this.iterationClicksMin.Location = new System.Drawing.Point(105, 92);
			this.iterationClicksMin.Name = "iterationClicksMin";
			this.iterationClicksMin.Size = new System.Drawing.Size(56, 20);
			this.iterationClicksMin.TabIndex = 2;
			this.iterationClicksMin.Text = "250";
			this.iterationClicksMin.Leave += new System.EventHandler(this.iterationClicksMin_Leave);
			// 
			// iterationClicksMax
			// 
			this.iterationClicksMax.Location = new System.Drawing.Point(169, 92);
			this.iterationClicksMax.Name = "iterationClicksMax";
			this.iterationClicksMax.Size = new System.Drawing.Size(56, 20);
			this.iterationClicksMax.TabIndex = 3;
			this.iterationClicksMax.Text = "300";
			this.iterationClicksMax.Leave += new System.EventHandler(this.iterationClicksMin_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(367, 156);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Click Radius:";
			// 
			// cClickRadius
			// 
			this.cClickRadius.Location = new System.Drawing.Point(442, 153);
			this.cClickRadius.Name = "cClickRadius";
			this.cClickRadius.Size = new System.Drawing.Size(56, 20);
			this.cClickRadius.TabIndex = 1;
			this.cClickRadius.Text = "10";
			// 
			// screenClickPanel
			// 
			this.screenClickPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.screenClickPanel.Controls.Add(this.cSavePosition);
			this.screenClickPanel.Controls.Add(this.label5);
			this.screenClickPanel.Controls.Add(this.screenX);
			this.screenClickPanel.Controls.Add(this.screenY);
			this.screenClickPanel.Controls.Add(this.label4);
			this.screenClickPanel.Location = new System.Drawing.Point(349, 55);
			this.screenClickPanel.Name = "screenClickPanel";
			this.screenClickPanel.Size = new System.Drawing.Size(171, 96);
			this.screenClickPanel.TabIndex = 27;
			this.screenClickPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screenClickPanel_MouseClick);
			// 
			// cSavePosition
			// 
			this.cSavePosition.AutoSize = true;
			this.cSavePosition.Checked = true;
			this.cSavePosition.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cSavePosition.Location = new System.Drawing.Point(6, 74);
			this.cSavePosition.Name = "cSavePosition";
			this.cSavePosition.Size = new System.Drawing.Size(91, 17);
			this.cSavePosition.TabIndex = 55;
			this.cSavePosition.Text = "Save Position";
			this.cSavePosition.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(363, 33);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 13);
			this.label10.TabIndex = 31;
			this.label10.Text = "Remaining:";
			// 
			// estimatedRemaining
			// 
			this.estimatedRemaining.AutoSize = true;
			this.estimatedRemaining.Location = new System.Drawing.Point(429, 32);
			this.estimatedRemaining.Name = "estimatedRemaining";
			this.estimatedRemaining.Size = new System.Drawing.Size(102, 13);
			this.estimatedRemaining.TabIndex = 44;
			this.estimatedRemaining.Text = "estimatedRemaining";
			// 
			// estimatedTime
			// 
			this.estimatedTime.AutoSize = true;
			this.estimatedTime.Location = new System.Drawing.Point(102, 153);
			this.estimatedTime.Name = "estimatedTime";
			this.estimatedTime.Size = new System.Drawing.Size(75, 13);
			this.estimatedTime.TabIndex = 43;
			this.estimatedTime.Text = "estimatedTime";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 153);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 13);
			this.label9.TabIndex = 42;
			this.label9.Text = "Estimated Time:";
			// 
			// cIterationCount
			// 
			this.cIterationCount.Location = new System.Drawing.Point(71, 55);
			this.cIterationCount.Name = "cIterationCount";
			this.cIterationCount.Size = new System.Drawing.Size(56, 20);
			this.cIterationCount.TabIndex = 33;
			this.cIterationCount.Text = "1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 40;
			this.label8.Text = "Iterations:";
			// 
			// cWaitMax
			// 
			this.cWaitMax.Location = new System.Drawing.Point(279, 55);
			this.cWaitMax.Name = "cWaitMax";
			this.cWaitMax.Size = new System.Drawing.Size(56, 20);
			this.cWaitMax.TabIndex = 37;
			this.cWaitMax.Text = "10000";
			// 
			// cWaitMin
			// 
			this.cWaitMin.Location = new System.Drawing.Point(217, 55);
			this.cWaitMin.Name = "cWaitMin";
			this.cWaitMin.Size = new System.Drawing.Size(56, 20);
			this.cWaitMin.TabIndex = 36;
			this.cWaitMin.Text = "5000";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(144, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 39;
			this.label7.Text = "Wait Range:";
			// 
			// clickMax
			// 
			this.clickMax.Location = new System.Drawing.Point(169, 118);
			this.clickMax.Name = "clickMax";
			this.clickMax.Size = new System.Drawing.Size(56, 20);
			this.clickMax.TabIndex = 35;
			this.clickMax.Text = "200";
			// 
			// clickMin
			// 
			this.clickMin.Location = new System.Drawing.Point(105, 118);
			this.clickMin.Name = "clickMin";
			this.clickMin.Size = new System.Drawing.Size(56, 20);
			this.clickMin.TabIndex = 34;
			this.clickMin.Text = "120";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(40, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 13);
			this.label6.TabIndex = 38;
			this.label6.Text = "Delay (ms):";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(224, 33);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(74, 13);
			this.label11.TabIndex = 45;
			this.label11.Text = "Elapsed Time:";
			// 
			// elapsedTime
			// 
			this.elapsedTime.AutoSize = true;
			this.elapsedTime.Location = new System.Drawing.Point(305, 33);
			this.elapsedTime.Name = "elapsedTime";
			this.elapsedTime.Size = new System.Drawing.Size(52, 13);
			this.elapsedTime.TabIndex = 46;
			this.elapsedTime.Text = "0:00:0.00";
			// 
			// cClickDetail
			// 
			this.cClickDetail.AutoSize = true;
			this.cClickDetail.Location = new System.Drawing.Point(231, 121);
			this.cClickDetail.Name = "cClickDetail";
			this.cClickDetail.Size = new System.Drawing.Size(24, 13);
			this.cClickDetail.TabIndex = 47;
			this.cClickDetail.Text = "0/0";
			// 
			// cIterationClicksDetail
			// 
			this.cIterationClicksDetail.AutoSize = true;
			this.cIterationClicksDetail.Location = new System.Drawing.Point(231, 95);
			this.cIterationClicksDetail.Name = "cIterationClicksDetail";
			this.cIterationClicksDetail.Size = new System.Drawing.Size(24, 13);
			this.cIterationClicksDetail.TabIndex = 48;
			this.cIterationClicksDetail.Text = "0/0";
			// 
			// waiting
			// 
			this.waiting.AutoSize = true;
			this.waiting.Location = new System.Drawing.Point(295, 95);
			this.waiting.Name = "waiting";
			this.waiting.Size = new System.Drawing.Size(40, 13);
			this.waiting.TabIndex = 49;
			this.waiting.Text = "waiting";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(136, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 50;
			this.label2.Text = "Total:";
			// 
			// totalClicks
			// 
			this.totalClicks.AutoSize = true;
			this.totalClicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.totalClicks.Location = new System.Drawing.Point(165, 33);
			this.totalClicks.Name = "totalClicks";
			this.totalClicks.Size = new System.Drawing.Size(32, 13);
			this.totalClicks.TabIndex = 51;
			this.totalClicks.Text = "total";
			// 
			// cAddAction
			// 
			this.cAddAction.Location = new System.Drawing.Point(246, 194);
			this.cAddAction.Name = "cAddAction";
			this.cAddAction.Size = new System.Drawing.Size(53, 23);
			this.cAddAction.TabIndex = 53;
			this.cAddAction.Text = "Add";
			this.cAddAction.UseVisualStyleBackColor = true;
			this.cAddAction.Click += new System.EventHandler(this.cAddAction_Click);
			// 
			// cActionList
			// 
			this.cActionList.FormattingEnabled = true;
			this.cActionList.Location = new System.Drawing.Point(15, 223);
			this.cActionList.Name = "cActionList";
			this.cActionList.Size = new System.Drawing.Size(401, 108);
			this.cActionList.TabIndex = 52;
			this.cActionList.SelectedIndexChanged += new System.EventHandler(this.cActionList_SelectedIndexChanged);
			// 
			// cUseActions
			// 
			this.cUseActions.AutoSize = true;
			this.cUseActions.Enabled = false;
			this.cUseActions.Location = new System.Drawing.Point(15, 194);
			this.cUseActions.Name = "cUseActions";
			this.cUseActions.Size = new System.Drawing.Size(83, 17);
			this.cUseActions.TabIndex = 54;
			this.cUseActions.Text = "Use Actions";
			this.cUseActions.UseVisualStyleBackColor = true;
			// 
			// cUpdateAction
			// 
			this.cUpdateAction.Enabled = false;
			this.cUpdateAction.Location = new System.Drawing.Point(305, 194);
			this.cUpdateAction.Name = "cUpdateAction";
			this.cUpdateAction.Size = new System.Drawing.Size(53, 23);
			this.cUpdateAction.TabIndex = 55;
			this.cUpdateAction.Text = "Update";
			this.cUpdateAction.UseVisualStyleBackColor = true;
			this.cUpdateAction.Click += new System.EventHandler(this.cUpdateAction_Click);
			// 
			// cMainMenu
			// 
			this.cMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.cMainMenu.Location = new System.Drawing.Point(0, 0);
			this.cMainMenu.Name = "cMainMenu";
			this.cMainMenu.Size = new System.Drawing.Size(560, 24);
			this.cMainMenu.TabIndex = 56;
			this.cMainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "L&oad...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "&Save...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// cSaveFileDialog
			// 
			this.cSaveFileDialog.DefaultExt = "txt";
			this.cSaveFileDialog.FileName = "WindowClicker.JSON.txt";
			this.cSaveFileDialog.InitialDirectory = "C:\\_drv\\Z\\Window Clicker";
			// 
			// cOpenFileDialog
			// 
			this.cOpenFileDialog.FileName = "WindowClicker.JSON.txt";
			this.cOpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			this.cOpenFileDialog.InitialDirectory = "C:\\_drv\\Z\\Window Clicker";
			// 
			// cDeleteAction
			// 
			this.cDeleteAction.Enabled = false;
			this.cDeleteAction.Location = new System.Drawing.Point(364, 194);
			this.cDeleteAction.Name = "cDeleteAction";
			this.cDeleteAction.Size = new System.Drawing.Size(53, 23);
			this.cDeleteAction.TabIndex = 57;
			this.cDeleteAction.Text = "Delete";
			this.cDeleteAction.UseVisualStyleBackColor = true;
			this.cDeleteAction.Click += new System.EventHandler(this.cDeleteAction_Click);
			// 
			// cActionCount
			// 
			this.cActionCount.AutoSize = true;
			this.cActionCount.Location = new System.Drawing.Point(99, 194);
			this.cActionCount.Name = "cActionCount";
			this.cActionCount.Size = new System.Drawing.Size(71, 13);
			this.cActionCount.TabIndex = 58;
			this.cActionCount.Text = "cActionCount";
			// 
			// cSkipAction
			// 
			this.cSkipAction.Location = new System.Drawing.Point(423, 223);
			this.cSkipAction.Name = "cSkipAction";
			this.cSkipAction.Size = new System.Drawing.Size(53, 23);
			this.cSkipAction.TabIndex = 59;
			this.cSkipAction.Text = "Skip >";
			this.cSkipAction.UseVisualStyleBackColor = true;
			this.cSkipAction.Click += new System.EventHandler(this.cSkipAction_Click);
			// 
			// cStatusStrip
			// 
			this.cStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cStatus,
            this.cProgressBar});
			this.cStatusStrip.Location = new System.Drawing.Point(0, 337);
			this.cStatusStrip.Name = "cStatusStrip";
			this.cStatusStrip.Size = new System.Drawing.Size(560, 22);
			this.cStatusStrip.TabIndex = 60;
			this.cStatusStrip.Text = "statusStrip1";
			// 
			// cStatus
			// 
			this.cStatus.Name = "cStatus";
			this.cStatus.Size = new System.Drawing.Size(384, 17);
			this.cStatus.Spring = true;
			this.cStatus.Text = "cStatus";
			this.cStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cProgressBar
			// 
			this.cProgressBar.Name = "cProgressBar";
			this.cProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.cProgressBar.Size = new System.Drawing.Size(150, 16);
			// 
			// currentLabel
			// 
			this.currentLabel.AutoSize = true;
			this.currentLabel.ForeColor = System.Drawing.SystemColors.Highlight;
			this.currentLabel.Location = new System.Drawing.Point(12, 33);
			this.currentLabel.Name = "currentLabel";
			this.currentLabel.Size = new System.Drawing.Size(44, 13);
			this.currentLabel.TabIndex = 61;
			this.currentLabel.Text = "Current:";
			this.currentLabel.Visible = false;
			// 
			// currentIteration
			// 
			this.currentIteration.AutoSize = true;
			this.currentIteration.ForeColor = System.Drawing.SystemColors.Highlight;
			this.currentIteration.Location = new System.Drawing.Point(62, 33);
			this.currentIteration.Name = "currentIteration";
			this.currentIteration.Size = new System.Drawing.Size(78, 13);
			this.currentIteration.TabIndex = 62;
			this.currentIteration.Text = "currentIteration";
			this.currentIteration.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 359);
			this.Controls.Add(this.currentIteration);
			this.Controls.Add(this.currentLabel);
			this.Controls.Add(this.cStatusStrip);
			this.Controls.Add(this.cSkipAction);
			this.Controls.Add(this.cActionCount);
			this.Controls.Add(this.cDeleteAction);
			this.Controls.Add(this.cUpdateAction);
			this.Controls.Add(this.cUseActions);
			this.Controls.Add(this.cAddAction);
			this.Controls.Add(this.cActionList);
			this.Controls.Add(this.totalClicks);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.waiting);
			this.Controls.Add(this.cIterationClicksDetail);
			this.Controls.Add(this.cClickDetail);
			this.Controls.Add(this.elapsedTime);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.estimatedRemaining);
			this.Controls.Add(this.estimatedTime);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cIterationCount);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cWaitMax);
			this.Controls.Add(this.cWaitMin);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.clickMax);
			this.Controls.Add(this.clickMin);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cClickRadius);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.iterationClicksMax);
			this.Controls.Add(this.iterationClicksMin);
			this.Controls.Add(this.iterationClicksLbl);
			this.Controls.Add(this.cClickScreen);
			this.Controls.Add(this.cMainMenu);
			this.Controls.Add(this.screenClickPanel);
			this.MainMenuStrip = this.cMainMenu;
			this.Name = "MainForm";
			this.Opacity = 0.8D;
			this.Text = "Window Clicker";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.screenClickPanel.ResumeLayout(false);
			this.screenClickPanel.PerformLayout();
			this.cMainMenu.ResumeLayout(false);
			this.cMainMenu.PerformLayout();
			this.cStatusStrip.ResumeLayout(false);
			this.cStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label screenY;
		private System.Windows.Forms.Label screenX;
		private System.Windows.Forms.Button cClickScreen;
		private System.Windows.Forms.Label iterationClicksLbl;
		private System.Windows.Forms.TextBox iterationClicksMin;
		private System.Windows.Forms.TextBox iterationClicksMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cClickRadius;
		private System.Windows.Forms.Panel screenClickPanel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label estimatedRemaining;
		private System.Windows.Forms.Label estimatedTime;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox cIterationCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox cWaitMax;
		private System.Windows.Forms.TextBox cWaitMin;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox clickMax;
		private System.Windows.Forms.TextBox clickMin;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label elapsedTime;
		private System.Windows.Forms.Label cClickDetail;
		private System.Windows.Forms.Label cIterationClicksDetail;
		private System.Windows.Forms.Label waiting;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label totalClicks;
		private System.Windows.Forms.Button cAddAction;
		private System.Windows.Forms.ListBox cActionList;
		private System.Windows.Forms.CheckBox cUseActions;
		private System.Windows.Forms.Button cUpdateAction;
		private System.Windows.Forms.MenuStrip cMainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog cSaveFileDialog;
		private System.Windows.Forms.OpenFileDialog cOpenFileDialog;
		private System.Windows.Forms.Button cDeleteAction;
		private System.Windows.Forms.Label cActionCount;
		private System.Windows.Forms.Button cSkipAction;
		private System.Windows.Forms.StatusStrip cStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel cStatus;
		private System.Windows.Forms.ToolStripProgressBar cProgressBar;
		private System.Windows.Forms.CheckBox cSavePosition;
		private System.Windows.Forms.Label currentLabel;
		private System.Windows.Forms.Label currentIteration;
	}
}