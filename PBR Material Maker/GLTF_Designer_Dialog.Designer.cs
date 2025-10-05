using System.Windows.Forms;
using System.Drawing;

namespace PBR_Material_Maker
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
            components = new System.ComponentModel.Container();
            labelBaseColor = new Label();
            labelOcclusion = new Label();
            labelRoughness = new Label();
            labelMetallic = new Label();
            labelNormal = new Label();
            labelEmission = new Label();
            buttonSave = new Button();
            buttonClear = new Button();
            panelFooter = new Panel();
            labelVersion = new Label();
            checkBoxKeepOntop = new CheckBox();
            textBoxMaterialName = new TextBox();
            pictureBoxEmission = new PictureBox();
            pictureBoxNormal = new PictureBox();
            pictureBoxMetallic = new PictureBox();
            pictureBoxRoughness = new PictureBox();
            pictureBoxOcclusion = new PictureBox();
            pictureBoxBaseColor = new PictureBox();
            labelAlpha = new Label();
            pictureBoxAlpha = new PictureBox();
            toolTip1 = new ToolTip(components);
            panelMaterialSelection = new Panel();
            comboBoxMaterialSelect = new ComboBox();
            comboBoxResolution = new ComboBox();
            checkBoxMaterialSelect = new CheckBox();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmission).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNormal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMetallic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoughness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOcclusion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBaseColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlpha).BeginInit();
            panelMaterialSelection.SuspendLayout();
            SuspendLayout();
            // 
            // labelBaseColor
            // 
            labelBaseColor.AutoSize = true;
            labelBaseColor.Location = new Point(10, 3);
            labelBaseColor.Name = "labelBaseColor";
            labelBaseColor.Size = new Size(68, 15);
            labelBaseColor.TabIndex = 2;
            labelBaseColor.Text = "&Base Color*";
            // 
            // labelOcclusion
            // 
            labelOcclusion.AutoSize = true;
            labelOcclusion.Location = new Point(7, 229);
            labelOcclusion.Name = "labelOcclusion";
            labelOcclusion.Size = new Size(60, 15);
            labelOcclusion.TabIndex = 4;
            labelOcclusion.Text = "&Occlusion";
            // 
            // labelRoughness
            // 
            labelRoughness.AutoSize = true;
            labelRoughness.Location = new Point(8, 342);
            labelRoughness.Name = "labelRoughness";
            labelRoughness.Size = new Size(65, 15);
            labelRoughness.TabIndex = 6;
            labelRoughness.Text = "&Roughness";
            // 
            // labelMetallic
            // 
            labelMetallic.AutoSize = true;
            labelMetallic.Location = new Point(7, 455);
            labelMetallic.Name = "labelMetallic";
            labelMetallic.Size = new Size(49, 15);
            labelMetallic.TabIndex = 8;
            labelMetallic.Text = "&Metallic";
            // 
            // labelNormal
            // 
            labelNormal.AutoSize = true;
            labelNormal.Location = new Point(7, 568);
            labelNormal.Name = "labelNormal";
            labelNormal.Size = new Size(47, 15);
            labelNormal.TabIndex = 10;
            labelNormal.Text = "&Normal";
            // 
            // labelEmission
            // 
            labelEmission.AutoSize = true;
            labelEmission.Location = new Point(8, 681);
            labelEmission.Name = "labelEmission";
            labelEmission.Size = new Size(54, 15);
            labelEmission.TabIndex = 12;
            labelEmission.Text = "&Emission";
            // 
            // buttonSave
            // 
            buttonSave.Enabled = false;
            buttonSave.ForeColor = SystemColors.ControlText;
            buttonSave.Location = new Point(13, 873);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(96, 23);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "&Save...";
            toolTip1.SetToolTip(buttonSave, "Packs Images and Makes a GLTF File.");
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonClear
            // 
            buttonClear.ForeColor = SystemColors.Desktop;
            buttonClear.Location = new Point(13, 899);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(96, 23);
            buttonClear.TabIndex = 14;
            buttonClear.Text = "&Clear";
            toolTip1.SetToolTip(buttonClear, "Clear all images");
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // panelFooter
            // 
            panelFooter.AllowDrop = true;
            panelFooter.BackColor = Color.Black;
            panelFooter.Controls.Add(labelVersion);
            panelFooter.Controls.Add(checkBoxKeepOntop);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.ForeColor = SystemColors.ControlDark;
            panelFooter.Location = new Point(0, 913);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(124, 53);
            panelFooter.TabIndex = 16;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(3, 7);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(53, 15);
            labelVersion.TabIndex = 2;
            labelVersion.Text = "{Version}";
            // 
            // checkBoxKeepOntop
            // 
            checkBoxKeepOntop.Appearance = Appearance.Button;
            checkBoxKeepOntop.Checked = true;
            checkBoxKeepOntop.CheckState = CheckState.Checked;
            checkBoxKeepOntop.Image = Properties.Resources.icons8_pin_16;
            checkBoxKeepOntop.Location = new Point(62, 5);
            checkBoxKeepOntop.Name = "checkBoxKeepOntop";
            checkBoxKeepOntop.Size = new Size(20, 20);
            checkBoxKeepOntop.TabIndex = 1;
            toolTip1.SetToolTip(checkBoxKeepOntop, "Keep Window on Top");
            checkBoxKeepOntop.UseVisualStyleBackColor = true;
            checkBoxKeepOntop.CheckedChanged += CheckBoxKeepOntop_CheckedChanged;
            // 
            // textBoxMaterialName
            // 
            textBoxMaterialName.BackColor = SystemColors.ControlDarkDark;
            textBoxMaterialName.Location = new Point(13, 847);
            textBoxMaterialName.Name = "textBoxMaterialName";
            textBoxMaterialName.Size = new Size(96, 23);
            textBoxMaterialName.TabIndex = 20;
            toolTip1.SetToolTip(textBoxMaterialName, "Material Name.\r\nAs shown in SecondLife.");
            // 
            // pictureBoxEmission
            // 
            pictureBoxEmission.BackColor = SystemColors.ControlLight;
            pictureBoxEmission.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxEmission.Location = new Point(14, 696);
            pictureBoxEmission.Name = "pictureBoxEmission";
            pictureBoxEmission.Size = new Size(95, 95);
            pictureBoxEmission.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmission.TabIndex = 10;
            pictureBoxEmission.TabStop = false;
            toolTip1.SetToolTip(pictureBoxEmission, "Emission Map.\r\nCan be left blank.");
            pictureBoxEmission.DragDrop += PictureBoxDragDrop;
            pictureBoxEmission.DragEnter += PictureBoxDragEnter;
            pictureBoxEmission.MouseDown += PictureBoxMouseDown;
            // 
            // pictureBoxNormal
            // 
            pictureBoxNormal.BackColor = SystemColors.ControlLight;
            pictureBoxNormal.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxNormal.Location = new Point(13, 583);
            pictureBoxNormal.Name = "pictureBoxNormal";
            pictureBoxNormal.Size = new Size(95, 95);
            pictureBoxNormal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNormal.TabIndex = 8;
            pictureBoxNormal.TabStop = false;
            toolTip1.SetToolTip(pictureBoxNormal, "Normal Map.");
            pictureBoxNormal.DragDrop += PictureBoxDragDrop;
            pictureBoxNormal.DragEnter += PictureBoxDragEnter;
            pictureBoxNormal.MouseDown += PictureBoxMouseDown;
            // 
            // pictureBoxMetallic
            // 
            pictureBoxMetallic.BackColor = SystemColors.ControlLight;
            pictureBoxMetallic.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxMetallic.Location = new Point(13, 470);
            pictureBoxMetallic.Name = "pictureBoxMetallic";
            pictureBoxMetallic.Size = new Size(95, 95);
            pictureBoxMetallic.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMetallic.TabIndex = 6;
            pictureBoxMetallic.TabStop = false;
            toolTip1.SetToolTip(pictureBoxMetallic, "Metalness data for ORM Map.\r\nCan be left blank.");
            pictureBoxMetallic.DragDrop += PictureBoxDragDrop;
            pictureBoxMetallic.DragEnter += PictureBoxDragEnter;
            pictureBoxMetallic.MouseDown += PictureBoxMouseDown;
            // 
            // pictureBoxRoughness
            // 
            pictureBoxRoughness.BackColor = SystemColors.ControlLight;
            pictureBoxRoughness.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxRoughness.Location = new Point(14, 357);
            pictureBoxRoughness.Name = "pictureBoxRoughness";
            pictureBoxRoughness.Size = new Size(95, 95);
            pictureBoxRoughness.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRoughness.TabIndex = 4;
            pictureBoxRoughness.TabStop = false;
            toolTip1.SetToolTip(pictureBoxRoughness, "Roughness data for ORM map.\r\nCan be left blank.");
            pictureBoxRoughness.DragDrop += PictureBoxDragDrop;
            pictureBoxRoughness.DragEnter += PictureBoxDragEnter;
            pictureBoxRoughness.MouseDown += PictureBoxMouseDown;
            // 
            // pictureBoxOcclusion
            // 
            pictureBoxOcclusion.BackColor = SystemColors.ControlLight;
            pictureBoxOcclusion.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxOcclusion.Location = new Point(13, 244);
            pictureBoxOcclusion.Name = "pictureBoxOcclusion";
            pictureBoxOcclusion.Size = new Size(95, 95);
            pictureBoxOcclusion.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOcclusion.TabIndex = 2;
            pictureBoxOcclusion.TabStop = false;
            toolTip1.SetToolTip(pictureBoxOcclusion, "Occlusion data for ORM Map.\r\nCan be left blank.");
            pictureBoxOcclusion.DragDrop += PictureBoxDragDrop;
            pictureBoxOcclusion.DragEnter += PictureBoxDragEnter;
            pictureBoxOcclusion.MouseDown += PictureBoxMouseDown;
            // 
            // pictureBoxBaseColor
            // 
            pictureBoxBaseColor.BackColor = SystemColors.ControlLight;
            pictureBoxBaseColor.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxBaseColor.Location = new Point(13, 18);
            pictureBoxBaseColor.Name = "pictureBoxBaseColor";
            pictureBoxBaseColor.Size = new Size(95, 95);
            pictureBoxBaseColor.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBaseColor.TabIndex = 0;
            pictureBoxBaseColor.TabStop = false;
            toolTip1.SetToolTip(pictureBoxBaseColor, "The RGB Data of Base Color.\r\nAny alpha in this image will be Stripped.");
            pictureBoxBaseColor.DragDrop += PictureBoxDragDrop;
            pictureBoxBaseColor.DragEnter += PictureBoxDragEnter;
            pictureBoxBaseColor.MouseDown += PictureBoxMouseDown;
            // 
            // labelAlpha
            // 
            labelAlpha.AutoSize = true;
            labelAlpha.Location = new Point(10, 116);
            labelAlpha.Name = "labelAlpha";
            labelAlpha.Size = new Size(38, 15);
            labelAlpha.TabIndex = 22;
            labelAlpha.Text = "Alpha";
            // 
            // pictureBoxAlpha
            // 
            pictureBoxAlpha.BackColor = SystemColors.ControlLight;
            pictureBoxAlpha.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxAlpha.Location = new Point(13, 131);
            pictureBoxAlpha.Name = "pictureBoxAlpha";
            pictureBoxAlpha.Size = new Size(95, 95);
            pictureBoxAlpha.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAlpha.TabIndex = 21;
            pictureBoxAlpha.TabStop = false;
            toolTip1.SetToolTip(pictureBoxAlpha, "Alpha data will be packed into Base Color.\r\nPass a Greyscale Image.\r\nAlpha will be extracted from the Red channel.\r\nLeave blank for no alpha channel.");
            pictureBoxAlpha.DragDrop += PictureBoxDragDrop;
            pictureBoxAlpha.DragEnter += PictureBoxDragEnter;
            pictureBoxAlpha.MouseDown += PictureBoxMouseDown;
            // 
            // panelMaterialSelection
            // 
            panelMaterialSelection.AllowDrop = true;
            panelMaterialSelection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMaterialSelection.BackColor = Color.Transparent;
            panelMaterialSelection.Controls.Add(labelBaseColor);
            panelMaterialSelection.Controls.Add(pictureBoxBaseColor);
            panelMaterialSelection.Controls.Add(labelAlpha);
            panelMaterialSelection.Controls.Add(pictureBoxAlpha);
            panelMaterialSelection.Controls.Add(labelOcclusion);
            panelMaterialSelection.Controls.Add(pictureBoxOcclusion);
            panelMaterialSelection.Controls.Add(labelRoughness);
            panelMaterialSelection.Controls.Add(pictureBoxRoughness);
            panelMaterialSelection.Controls.Add(labelMetallic);
            panelMaterialSelection.Controls.Add(pictureBoxMetallic);
            panelMaterialSelection.Controls.Add(labelNormal);
            panelMaterialSelection.Controls.Add(pictureBoxNormal);
            panelMaterialSelection.Controls.Add(labelEmission);
            panelMaterialSelection.Controls.Add(pictureBoxEmission);
            panelMaterialSelection.Controls.Add(comboBoxMaterialSelect);
            panelMaterialSelection.Controls.Add(comboBoxResolution);
            panelMaterialSelection.Controls.Add(textBoxMaterialName);
            panelMaterialSelection.Controls.Add(buttonSave);
            panelMaterialSelection.Controls.Add(buttonClear);
            panelMaterialSelection.Location = new Point(-5, 1);
            panelMaterialSelection.Margin = new Padding(0);
            panelMaterialSelection.Name = "panelMaterialSelection";
            panelMaterialSelection.Padding = new Padding(3);
            panelMaterialSelection.Size = new Size(129, 935);
            panelMaterialSelection.TabIndex = 23;
            // 
            // comboBoxMaterialSelect
            // 
            comboBoxMaterialSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterialSelect.FormattingEnabled = true;
            comboBoxMaterialSelect.Location = new Point(3, 800);
            comboBoxMaterialSelect.Name = "comboBoxMaterialSelect";
            comboBoxMaterialSelect.Size = new Size(115, 23);
            comboBoxMaterialSelect.TabIndex = 1;
            // 
            // comboBoxResolution
            // 
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxResolution.FormattingEnabled = true;
            comboBoxResolution.Items.AddRange(new object[] { "Don't Resize", "2048 * 2048", "1024 * 1024", "512 * 512", "256 * 256", "128 * 128", "64 * 64", "32 * 32", "16 * 16", "8 * 8", "Custom..." });
            comboBoxResolution.Location = new Point(13, 818);
            comboBoxResolution.Name = "comboBoxResolution";
            comboBoxResolution.Size = new Size(96, 23);
            comboBoxResolution.TabIndex = 23;
            comboBoxResolution.SelectedIndexChanged += ComboBoxResolution_SelectedIndexChanged;
            // 
            // checkBoxMaterialSelect
            // 
            checkBoxMaterialSelect.AutoSize = true;
            checkBoxMaterialSelect.Location = new Point(3, 830);
            checkBoxMaterialSelect.Name = "checkBoxMaterialSelect";
            checkBoxMaterialSelect.Size = new Size(116, 19);
            checkBoxMaterialSelect.TabIndex = 24;
            checkBoxMaterialSelect.Text = "Materialauswahl aktivieren";
            checkBoxMaterialSelect.UseVisualStyleBackColor = true;
            checkBoxMaterialSelect.CheckedChanged += CheckBoxMaterialSelect_CheckedChanged;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(124, 1200);
            Controls.Add(panelMaterialSelection);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlLightLight;
            MaximizeBox = false;
            MaximumSize = new Size(140, 1280);
            MinimizeBox = false;
            MinimumSize = new Size(140, 1080);
            Name = "MainForm";
            ShowIcon = false;
            Text = "GLTF Packer";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            ResizeEnd += Form1_ResizeEnd;
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmission).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNormal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMetallic).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoughness).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOcclusion).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBaseColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlpha).EndInit();
            panelMaterialSelection.ResumeLayout(false);
            panelMaterialSelection.PerformLayout();
            ResumeLayout(false);
            // 
            // Diese Zeilen wurden hinzugefügt:
            // 
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelMaterialSelection.AutoSize = true;
            this.panelMaterialSelection.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelMaterialSelection.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelMaterialSelection.AutoScroll = false;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 18; // Anzahl der Controls im Panel
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Controls in die Tabelle einfügen:
            tableLayoutPanel.Controls.Add(labelBaseColor, 0, 0);
            tableLayoutPanel.Controls.Add(pictureBoxBaseColor, 0, 1);
            tableLayoutPanel.Controls.Add(labelAlpha, 0, 2);
            tableLayoutPanel.Controls.Add(pictureBoxAlpha, 0, 3);
            tableLayoutPanel.Controls.Add(labelOcclusion, 0, 4);
            tableLayoutPanel.Controls.Add(pictureBoxOcclusion, 0, 5);
            tableLayoutPanel.Controls.Add(labelRoughness, 0, 6);
            tableLayoutPanel.Controls.Add(pictureBoxRoughness, 0, 7);
            tableLayoutPanel.Controls.Add(labelMetallic, 0, 8);
            tableLayoutPanel.Controls.Add(pictureBoxMetallic, 0, 9);
            tableLayoutPanel.Controls.Add(labelNormal, 0, 10);
            tableLayoutPanel.Controls.Add(pictureBoxNormal, 0, 11);
            tableLayoutPanel.Controls.Add(labelEmission, 0, 12);
            tableLayoutPanel.Controls.Add(pictureBoxEmission, 0, 13);
            tableLayoutPanel.Controls.Add(comboBoxMaterialSelect, 0, 14);
            tableLayoutPanel.Controls.Add(comboBoxResolution, 0, 15);
            tableLayoutPanel.Controls.Add(textBoxMaterialName, 0, 16);
            tableLayoutPanel.Controls.Add(buttonSave, 0, 18);
            tableLayoutPanel.Controls.Add(buttonClear, 0, 19);

            // Das TableLayoutPanel ins Panel einfügen:
            panelMaterialSelection.Controls.Clear();
            panelMaterialSelection.Controls.Add(tableLayoutPanel);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBaseColor;
        private System.Windows.Forms.Label labelBaseColor;
        private System.Windows.Forms.Label labelOcclusion;
        private System.Windows.Forms.PictureBox pictureBoxOcclusion;
        private System.Windows.Forms.Label labelRoughness;
        private System.Windows.Forms.PictureBox pictureBoxRoughness;
        private System.Windows.Forms.Label labelMetallic;
        private System.Windows.Forms.PictureBox pictureBoxMetallic;
        private System.Windows.Forms.Label labelNormal;
        private System.Windows.Forms.PictureBox pictureBoxNormal;
        private System.Windows.Forms.Label labelEmission;
        private System.Windows.Forms.PictureBox pictureBoxEmission;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.CheckBox checkBoxKeepOntop;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.PictureBox pictureBoxAlpha;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxMaterialSelect;
        private System.Windows.Forms.Panel panelMaterialSelection;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.CheckBox checkBoxMaterialSelect;
    }
}

