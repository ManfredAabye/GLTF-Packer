namespace PBR_Material_Maker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.checkBoxKeepOntop = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMaterialName = new System.Windows.Forms.TextBox();
            this.pictureBoxEmission = new System.Windows.Forms.PictureBox();
            this.pictureBoxNormal = new System.Windows.Forms.PictureBox();
            this.pictureBoxMetallic = new System.Windows.Forms.PictureBox();
            this.pictureBoxRoughness = new System.Windows.Forms.PictureBox();
            this.pictureBoxOcclusion = new System.Windows.Forms.PictureBox();
            this.pictureBoxBaseColor = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxAlpha = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMetallic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOcclusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBaseColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlpha)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Base Color*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Occlusion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Roughness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "&Metallic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 568);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "&Normal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 681);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "&Emission";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSave.Location = new System.Drawing.Point(13, 873);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "&Save...";
            this.toolTip1.SetToolTip(this.buttonSave, "Packs Images and Makes a GLTF File.");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonClear.Location = new System.Drawing.Point(13, 899);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(96, 23);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "&Clear";
            this.toolTip1.SetToolTip(this.buttonClear, "Clear all images");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.checkBoxKeepOntop);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(0, 938);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 53);
            this.panel1.TabIndex = 16;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel1.Location = new System.Drawing.Point(56, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 15);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Web Page";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(3, 7);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(53, 15);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "{Version}";
            // 
            // checkBoxKeepOntop
            // 
            this.checkBoxKeepOntop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxKeepOntop.Checked = true;
            this.checkBoxKeepOntop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepOntop.Image = global::PBR_Material_Maker.Properties.Resources.icons8_pin_16;
            this.checkBoxKeepOntop.Location = new System.Drawing.Point(3, 30);
            this.checkBoxKeepOntop.Name = "checkBoxKeepOntop";
            this.checkBoxKeepOntop.Size = new System.Drawing.Size(20, 20);
            this.checkBoxKeepOntop.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBoxKeepOntop, "Keep Window on Top");
            this.checkBoxKeepOntop.UseVisualStyleBackColor = true;
            this.checkBoxKeepOntop.CheckedChanged += new System.EventHandler(this.CheckBoxKeepOntop_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "By extrude.ragu";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxMaterialName.Location = new System.Drawing.Point(13, 847);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(96, 23);
            this.textBoxMaterialName.TabIndex = 20;
            this.toolTip1.SetToolTip(this.textBoxMaterialName, "Material Name.\r\nAs shown in SecondLife.");
            // 
            // pictureBoxEmission
            // 
            this.pictureBoxEmission.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxEmission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxEmission.Location = new System.Drawing.Point(14, 696);
            this.pictureBoxEmission.Name = "pictureBoxEmission";
            this.pictureBoxEmission.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxEmission.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmission.TabIndex = 10;
            this.pictureBoxEmission.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxEmission, "Emission Map.\r\nCan be left blank.");
            this.pictureBoxEmission.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxEmission.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxEmission.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // pictureBoxNormal
            // 
            this.pictureBoxNormal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxNormal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxNormal.Location = new System.Drawing.Point(13, 583);
            this.pictureBoxNormal.Name = "pictureBoxNormal";
            this.pictureBoxNormal.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNormal.TabIndex = 8;
            this.pictureBoxNormal.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxNormal, "Normal Map.");
            this.pictureBoxNormal.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxNormal.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxNormal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // pictureBoxMetallic
            // 
            this.pictureBoxMetallic.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxMetallic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMetallic.Location = new System.Drawing.Point(13, 470);
            this.pictureBoxMetallic.Name = "pictureBoxMetallic";
            this.pictureBoxMetallic.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxMetallic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMetallic.TabIndex = 6;
            this.pictureBoxMetallic.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMetallic, "Metalness data for ORM Map.\r\nCan be left blank.");
            this.pictureBoxMetallic.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxMetallic.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxMetallic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // pictureBoxRoughness
            // 
            this.pictureBoxRoughness.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxRoughness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRoughness.Location = new System.Drawing.Point(14, 357);
            this.pictureBoxRoughness.Name = "pictureBoxRoughness";
            this.pictureBoxRoughness.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxRoughness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRoughness.TabIndex = 4;
            this.pictureBoxRoughness.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxRoughness, "Roughness data for ORM map.\r\nCan be left blank.");
            this.pictureBoxRoughness.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxRoughness.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxRoughness.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // pictureBoxOcclusion
            // 
            this.pictureBoxOcclusion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxOcclusion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOcclusion.Location = new System.Drawing.Point(13, 244);
            this.pictureBoxOcclusion.Name = "pictureBoxOcclusion";
            this.pictureBoxOcclusion.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxOcclusion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOcclusion.TabIndex = 2;
            this.pictureBoxOcclusion.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxOcclusion, "Occlusion data for ORM Map.\r\nCan be left blank.");
            this.pictureBoxOcclusion.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxOcclusion.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxOcclusion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // pictureBoxBaseColor
            // 
            this.pictureBoxBaseColor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxBaseColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBaseColor.Location = new System.Drawing.Point(13, 18);
            this.pictureBoxBaseColor.Name = "pictureBoxBaseColor";
            this.pictureBoxBaseColor.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxBaseColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBaseColor.TabIndex = 0;
            this.pictureBoxBaseColor.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBaseColor, "The RGB Data of Base Color.\r\nAny alpha in this image will be Stripped.");
            this.pictureBoxBaseColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxBaseColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxBaseColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Alpha";
            // 
            // pictureBoxAlpha
            // 
            this.pictureBoxAlpha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxAlpha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxAlpha.Location = new System.Drawing.Point(13, 131);
            this.pictureBoxAlpha.Name = "pictureBoxAlpha";
            this.pictureBoxAlpha.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxAlpha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlpha.TabIndex = 21;
            this.pictureBoxAlpha.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxAlpha, "Alpha data will be packed into Base Color.\r\nPass a Greyscale Image.\r\nAlpha will b" +
        "e extracted from the Red channel.\r\nLeave blank for no alpha channel.");
            this.pictureBoxAlpha.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDrop);
            this.pictureBoxAlpha.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragEnter);
            this.pictureBoxAlpha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.comboBoxResolution);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBoxBaseColor);
            this.panel2.Controls.Add(this.pictureBoxAlpha);
            this.panel2.Controls.Add(this.pictureBoxOcclusion);
            this.panel2.Controls.Add(this.textBoxMaterialName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBoxRoughness);
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.pictureBoxMetallic);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBoxEmission);
            this.panel2.Controls.Add(this.pictureBoxNormal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(-5, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(129, 935);
            this.panel2.TabIndex = 23;
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "Don\'t Resize",
            "2048 * 2048",
            "1024 * 1024",
            "512 * 512",
            "256 * 256",
            "128 * 128",
            "64 * 64",
            "32 * 32",
            "16 * 16",
            "8 * 8",
            "Custom..."});
            this.comboBoxResolution.Location = new System.Drawing.Point(13, 818);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(96, 23);
            this.comboBoxResolution.TabIndex = 23;
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.ComboBoxResolution_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(124, 991);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(140, 1030);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(140, 400);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "GLTF Packer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMetallic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOcclusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBaseColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlpha)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBaseColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxOcclusion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxRoughness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxMetallic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxNormal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxEmission;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private System.Windows.Forms.CheckBox checkBoxKeepOntop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxAlpha;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxResolution;
    }
}

