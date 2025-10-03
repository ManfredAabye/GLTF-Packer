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
using System.Threading.Tasks;
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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

        private async void ButtonSave_Click(object sender, EventArgs e)
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

            // Bitmap col = new Bitmap(pictureBoxBaseColor.ImageLocation);

            // Generiere alle Maps aus Albedo
            Bitmap col = new Bitmap(pictureBoxBaseColor.ImageLocation);
            Bitmap nrm = GenerateNormalMap(col, 0.20f);
            Bitmap bOcclusion = GenerateOcclusionMap(col);
            Bitmap bRoughness = GenerateRoughnessMap(col, 0.20f);
            Bitmap bMetallic = GenerateMetallicMap(col);
            Bitmap emission = GenerateEmissionMap(col);
            Bitmap alpha = GenerateAlphaMap(col);

            // Optional: Resize
            if (resize) { nrm = ResizeImage(nrm, resizeX, resizeY); bOcclusion = ResizeImage(bOcclusion, resizeX, resizeY); bRoughness = ResizeImage(bRoughness, resizeX, resizeY); bMetallic = ResizeImage(bMetallic, resizeX, resizeY); emission = ResizeImage(emission, resizeX, resizeY); alpha = ResizeImage(alpha, resizeX, resizeY); col = ResizeImage(col, resizeX, resizeY); }

            // Speichern
            string gltf_output_dir = Path.Combine(Path.GetDirectoryName(pictureBoxBaseColor.ImageLocation), "gltf_textures");
            Directory.CreateDirectory(gltf_output_dir);
            nrm.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_nrm.png"), System.Drawing.Imaging.ImageFormat.Png);
            bOcclusion.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_occ.png"), System.Drawing.Imaging.ImageFormat.Png);
            bRoughness.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_rough.png"), System.Drawing.Imaging.ImageFormat.Png);
            bMetallic.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_metal.png"), System.Drawing.Imaging.ImageFormat.Png);
            emission.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_emission.png"), System.Drawing.Imaging.ImageFormat.Png);
            alpha.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_alpha.png"), System.Drawing.Imaging.ImageFormat.Png);
            col.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_col.png"), System.Drawing.Imaging.ImageFormat.Png);


            string orm_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_orm.png");
            orm_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, orm_file_path).Replace(@"\", "/").TrimStart('.');
            string col_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_col.png");
            col_file_path = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, col_file_path).Replace(@"\", "/").TrimStart('.');
            string nrm_file_path = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_nrm.png");
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
                string emission_file_path_local = Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_emission.png");
                Bitmap emissionBmp = new Bitmap(pictureBoxEmission.ImageLocation);
                if (resize) emissionBmp = ResizeImage(emissionBmp, resizeX, resizeY);
                emissionBmp.Save(emission_file_path_local);
                string emission_file_path_relative = Utils.GetRelativePath(pictureBoxBaseColor.ImageLocation, emission_file_path_local).Replace(@"\", "/").TrimStart('.');
                o["images"].Last.AddAfterSelf(JToken.FromObject(new ImageToken(emission_file_path_relative)));
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
            await Task.Delay(3000);
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

        private Bitmap GenerateSolidColor(byte r, byte g, byte b, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.FromArgb(r, g, b));
            }
            return bmp;
        }

        private Bitmap GenerateFlatNormal(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                // Ein flaches Normal-Map-Bild: RGB(128,128,255) = Vektor (0,0,1)
                gfx.Clear(Color.FromArgb(128, 128, 255));
            }
            return bmp;
        }

        private Bitmap GenerateBlack(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.Black);
            }
            return bmp;
        }

        // --- Hilfsfunktionen für PBR-Generierung aus Albedo ---

        // Normalmap aus Albedo (bereits vorhanden)
        private Bitmap GenerateNormalMap(Bitmap albedo, float embossStrength = 0.05f)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap normalMap = new Bitmap(width, height);

            // Graustufen aus Albedo
            float[,] gray = new float[width, height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    gray[x, y] = (c.R + c.G + c.B) / 3f / 255f;
                }

            // Sobel-Operator für X/Y
            int[,] sx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sy = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    float dx = 0, dy = 0;
                    for (int ky = -1; ky <= 1; ky++)
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            dx += gray[x + kx, y + ky] * sx[ky + 1, kx + 1];
                            dy += gray[x + kx, y + ky] * sy[ky + 1, kx + 1];
                        }

                    dx *= embossStrength;
                    dy *= embossStrength;

                    // Normalenvektor berechnen
                    float dz = 1.0f;
                    float len = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    float nx = dx / len;
                    float ny = dy / len;
                    float nz = dz / len;

                    // In RGB umwandeln
                    int r = (int)((nx * 0.5f + 0.5f) * 255);
                    int g = (int)((ny * 0.5f + 0.5f) * 255);
                    int b = (int)((nz * 0.5f + 0.5f) * 255);

                    normalMap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            // Rand auffüllen
            for (int x = 0; x < width; x++)
            {
                normalMap.SetPixel(x, 0, Color.FromArgb(128, 128, 255));
                normalMap.SetPixel(x, height - 1, Color.FromArgb(128, 128, 255));
            }
            for (int y = 0; y < height; y++)
            {
                normalMap.SetPixel(0, y, Color.FromArgb(128, 128, 255));
                normalMap.SetPixel(width - 1, y, Color.FromArgb(128, 128, 255));
            }

            return normalMap;
        }

        // Occlusion aus Albedo (Helligkeit, invertiert für Schatten)
        private Bitmap GenerateOcclusionMap(Bitmap albedo)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap occ = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int gray = 255 - (int)((c.R + c.G + c.B) / 3);
                    occ.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            return occ;
        }

        // Roughness aus Albedo (Helligkeit, invertiert für rauere Flächen)
        private Bitmap GenerateRoughnessMap(Bitmap albedo, float effectStrength = 0.20f)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap rough = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int gray = 255 - (int)(((c.R + c.G + c.B) / 3) * effectStrength);
                    rough.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            return rough;
        }

        // Metallic aus Albedo (Helligkeit, optional Schwellenwert)
        private Bitmap GenerateMetallicMap(Bitmap albedo, int threshold = 200)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap metal = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    int value = gray > threshold ? 255 : 0;
                    metal.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            return metal;
        }

        // Emission aus Albedo (optional: Helligkeit, hier einfach übernommen)
        private Bitmap GenerateEmissionMap(Bitmap albedo)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap emission = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    emission.SetPixel(x, y, c);
                }
            return emission;
        }

        // Alpha aus Albedo (optional: Helligkeit, hier voll transparent)
        private Bitmap GenerateAlphaMap(Bitmap albedo)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap alpha = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int a = 255; // oder z.B. (c.R + c.G + c.B) / 3 für Helligkeit
                    alpha.SetPixel(x, y, Color.FromArgb(a, c.R, c.G, c.B));
                }
            return alpha;
        }
    }
}
