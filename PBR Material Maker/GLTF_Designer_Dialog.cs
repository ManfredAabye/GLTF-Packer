using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PBR_Material_Maker
{
    public partial class Form1 : Form
    {
        bool dropValid = false;
        string dropFilename;

        public Form1()
        {
            InitializeComponent();
            #region AllowDrop on all PictureBoxes on the control.
            AllowAllPictureBoxDragDrop(Controls);
            #endregion
            TopMost = true;

            Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = appVersion.Major + "." + appVersion.Minor + "." + appVersion.Build;
        }

        private static void AllowAllPictureBoxDragDrop(IEnumerable controlCollection)
        {
            foreach (var control in controlCollection)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.AllowDrop = true;
                }
                if (control is Panel panel)
                {
                    AllowAllPictureBoxDragDrop(panel.Controls);
                }
            }
        }

        /// <summary>
        /// When the user is dragging a file or folder over any picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxDragEnter(object sender, DragEventArgs e)
        {
            try
            {
                Debug.WriteLine("DragEnter");
                Array data = e.Data.GetData("FileDrop") as Array;
                dropFilename = ((string[])data)[0];

                string ext = Path.GetExtension(dropFilename).ToLower();
                if ((ext == ".jpg") || (ext == ".png"))
                {
                    e.Effect = DragDropEffects.Copy;
                    dropValid = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception during drag enter: " + ex.ToString());
            }
            e.Effect = DragDropEffects.None;
            dropValid = false;
        }

        private void PictureBoxDragDrop(object sender, DragEventArgs e)
        {
            if (dropValid)
            {
                ((PictureBox)sender).ImageLocation = dropFilename;
                if (sender == pictureBoxBaseColor)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dropFilename);
                    string[] ext_base_col = new string[] { "_albedo", "_base", "_color", "_col", "_diffuse", "_diff", "_basecol", "_basecolor" };
                    int i = ext_base_col.Length;
                    while (i-- > 0)
                    {
                        if (fileName.ToLower().EndsWith(ext_base_col[i]))
                        {
                            fileName = fileName.Substring(0, fileName.Length - ext_base_col[i].Length);
                        }
                    }
                    textBoxMaterialName.Text = fileName;
                    Autofill_from_color(textBoxMaterialName.Text, Path.GetDirectoryName(dropFilename), Path.GetExtension(dropFilename).ToLower());
                }
            }
            buttonSave.Enabled = pictureBoxBaseColor.ImageLocation != null;
        }

        private void Autofill_from_color(string mat_name, string dir, string extension)
        {
            string search_pattern = mat_name + "*" + extension;
            string[] files = Directory.GetFiles(dir, search_pattern);
            string[] ext_normals = new string[] { "_normal", "_norm", "_nrml", "_nrm", "_nor" };
            string[] ext_occlusion = new string[] { "_ambient", "_occlusion", "_ao", "_ambientocclusion" };
            string[] ext_metallic = new string[] { "_metallic", "_metalness", "_mtl", "_metal" };
            string[] ext_roughness = new string[] { "_roughness", "_rough", "_roug", "_rgh" };
            string[] ext_emission = new string[] { "_emission", "_emiss", "_emit" };
            string[] ext_alpha = new string[] { "_alpha", "_transparency" };
            foreach (string file in files)
            {
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_normals)) { pictureBoxNormal.ImageLocation = file; continue; }
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_occlusion)) { pictureBoxOcclusion.ImageLocation = file; continue; }
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_metallic)) { pictureBoxMetallic.ImageLocation = file; continue; }
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_roughness)) { pictureBoxRoughness.ImageLocation = file; continue; }
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_emission)) { pictureBoxEmission.ImageLocation = file; continue; }
                if (EndsWithAnyCaseInsensitive(Path.GetFileNameWithoutExtension(file), ext_alpha)) { pictureBoxAlpha.ImageLocation = file; continue; }

            }
        }

        private bool EndsWithAnyCaseInsensitive(string text, string[] endings)
        {
            text = text.ToLower();
            foreach (var ending in endings)
            {
                if (text.EndsWith(ending.ToLower())) return true;
            }
            return false;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is PictureBox)
                {
                    ((PictureBox)control).ImageLocation = null;
                }
            }
            buttonSave.Enabled = pictureBoxBaseColor.ImageLocation != null;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxBaseColor.ImageLocation == null)
            {
                // Can't save.
                MessageBox.Show("Base Color Required");
                return;
            }
            #region Get/Parse resize parameter
            bool resize = false;
            int resizeX = 1024;
            int resizeY = 1024;
            if (comboBoxResolution.SelectedIndex != 0)
            {
                resize = true;
                string strRes = comboBoxResolution.Text;

                if (strRes == "")
                {
                    strRes = comboBoxResolution.Items[comboBoxResolution.SelectedIndex].ToString();
                }
                MessageBox.Show("strRes " + strRes);
                if (strRes.Contains("*"))
                {
                    string[] tmp = strRes.Split('*');
                    if (tmp.Length != 2)
                    {
                        // User error
                        MessageBox.Show("Enter a valid resolution in the format 1024 * 1024", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            resizeX = int.Parse(tmp[0]);
                            resizeY = int.Parse(tmp[1]);
                        }
                        catch (Exception)
                        {
                            // User error
                            MessageBox.Show("Enter a valid resolution in the format 1024 * 1024", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // User error..
                    MessageBox.Show("Enter a valid resolution in the format 1024 * 1024", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            #endregion

            string txtBefore = buttonSave.Text;
            buttonSave.Text = "Please Wait";
            Enabled = false;
            UseWaitCursor = true;

            string resourceData = Encoding.UTF8.GetString(Properties.Resources.pavement_03_4k_TEST2);
            JObject o = JObject.Parse(resourceData);

            string gltf_output_dir = Path.Combine(Path.GetDirectoryName(pictureBoxBaseColor.ImageLocation), "gltf_textures");
            string col_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_col.png");
            Bitmap col = new Bitmap(pictureBoxBaseColor.ImageLocation);

            Bitmap bOcclusion;
            Bitmap bRoughness;
            Bitmap bMetallic;
            if (pictureBoxOcclusion.ImageLocation != null)
            {
                bOcclusion = new Bitmap(pictureBoxOcclusion.ImageLocation);
            }
            else
            {
                bOcclusion = Utils.GenerateSolidColor(255, 255, 255);
            }
            if (pictureBoxRoughness.ImageLocation != null)
            {
                bRoughness = new Bitmap(pictureBoxRoughness.ImageLocation);
            }
            else
            {
                bRoughness = Utils.GenerateSolidColor(255, 255, 255);
            }
            if (pictureBoxMetallic.ImageLocation != null)
            {
                bMetallic = new Bitmap(pictureBoxMetallic.ImageLocation);
                o["materials"][0]["pbrMetallicRoughness"]["metallicFactor"] = 1.0f;
            }
            else
            {
                bMetallic = Utils.GenerateSolidColor(255, 255, 255);
                o["materials"][0]["pbrMetallicRoughness"]["metallicFactor"] = 0.0f;
            }


            Directory.CreateDirectory(gltf_output_dir);
            string orm_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_orm.png");
            Bitmap orm = Utils.CombineChannels(bOcclusion, bRoughness, bMetallic, col.Width, col.Height);
            if (resize) orm = ResizeImage(orm, resizeX, resizeY);
            orm.Save(orm_file_path, System.Drawing.Imaging.ImageFormat.Png);

            if (pictureBoxAlpha.ImageLocation != null)
            {
                Bitmap alpha = new Bitmap(pictureBoxAlpha.ImageLocation);
                col = Utils.CombineChannels(col, col, col, alpha);
            }
            if (resize) col = ResizeImage(col, resizeX, resizeY);
            col.Save(col_file_path, System.Drawing.Imaging.ImageFormat.Png);

            string nrm_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_nrm.png");
            if (pictureBoxNormal.ImageLocation != null)
            {
                Bitmap nrm = new Bitmap(pictureBoxNormal.ImageLocation);
                if (resize) nrm = ResizeImage(nrm, resizeX, resizeY);
                nrm.Save(nrm_file_path, System.Drawing.Imaging.ImageFormat.Png);
            }

            orm_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, orm_file_path).Replace(@"\", "/").TrimStart('.');
            col_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, col_file_path).Replace(@"\", "/").TrimStart('.');
            nrm_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, nrm_file_path).Replace(@"\", "/").TrimStart('.');


            o["images"][0]["mimeType"] = "image/png";
            o["images"][1]["mimeType"] = "image/png";
            o["images"][2]["mimeType"] = "image/png";

            o["images"][1]["uri"] = "." + col_file_path;

            o["images"][2]["uri"] = "." + orm_file_path;
            if (pictureBoxNormal.ImageLocation != null)
            {
                o["images"][0]["uri"] = "." + nrm_file_path;
            }
            else
            {
                o["materials"][0]["normalTexture"] = null;
            }
            o["materials"][0]["name"] = textBoxMaterialName.Text;


            if (pictureBoxEmission.ImageLocation != null)
            {
                string emission_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_emission.png");
                Bitmap emission = new Bitmap(pictureBoxEmission.ImageLocation);
                if (resize) emission = ResizeImage(emission, resizeX, resizeY);
                emission.Save(emission_file_path);
                emission_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, emission_file_path).Replace(@"\", "/").TrimStart('.');
                o["images"].Last.AddAfterSelf(JToken.FromObject(new ImageToken(emission_file_path)));
                o["textures"].Last.AddAfterSelf(JToken.FromObject(new SourceToken(3)));
                o["materials"][0]["emissiveTexture"] = JToken.FromObject(new IndexToken(3));
                float[] emissiveFactor = new float[] { 1.0f, 1.0f, 1.0f };
                o["materials"][0]["emissiveFactor"] = JArray.FromObject(emissiveFactor);

            }

            o["materials"][0]["doubleSided"] = false;
            Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string strVers = +appVersion.Major + "." + appVersion.Minor + "." + appVersion.Build;
            o["asset"]["generator"] = "GLTF Packer by Ai (extrude.ragu) " + strVers;

            o["asset"]["version"] = "2.0";

            string gltf_path = Path.Combine(Path.GetDirectoryName(pictureBoxBaseColor.ImageLocation), textBoxMaterialName.Text + ".gltf");
            File.WriteAllText(gltf_path, JsonConvert.SerializeObject(o, Formatting.Indented));

            UseWaitCursor = false;
            buttonSave.Text = "Saved!";
            this.Refresh();
            Thread.Sleep(3000);
            Enabled = true;
            buttonSave.Text = txtBefore;
        }

        // SO 1922040
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void CheckBoxKeepOntop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBoxKeepOntop.Checked;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://aiaicapta.in/gltf-packer/");
            Process.Start(sInfo);
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.ImageLocation = null;
            buttonSave.Enabled = pictureBoxBaseColor.ImageLocation != null;
        }

        private void Ensure_width()
        {
            if (this.Height == 1030)
            {
                this.MinimumSize = new Size(140, 400);
                this.MaximumSize = new Size(140, 1030);
            }
            else
            {
                this.MinimumSize = new Size(150, 400);
                this.MaximumSize = new Size(150, 1030);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Ensure_width();
            comboBoxResolution.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cfg = Program.ProgramConfig;
            Height = cfg.WindowHeight;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveProgramConfig();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Ensure_width();
            Program.ProgramConfig.WindowHeight = Height;

        }

        private void ComboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxResolution.SelectedIndex == (comboBoxResolution.Items.Count - 1))
            {
                // Selected Custom Resolution
                comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxResolution.SelectedText = "1024 * 1024";
                comboBoxResolution.SelectAll();

            }
            else
            {
                comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
