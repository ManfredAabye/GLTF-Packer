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
        private dynamic materialConfig;

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

            // Standard-Konfiguration
            var defaultConfig = new {
                NormalStrength = 0.20,
                RoughnessStrength = 0.20,
                OcclusionStrength = 1.0,
                MetallicThreshold = 200,
                EmissionStrength = 1.0,
                AlphaStrength = 1.0,
                BaseColorTint = new float[] { 1.0f, 1.0f, 1.0f },
                NormalMapType = "sobel",
                RoughnessInvert = false,
                MetallicIntensity = 1.0f,
                EmissionColor = new float[] { 1.0f, 1.0f, 1.0f },
                AlphaMode = "opaque"
            };

            // Konfiguration laden oder anlegen
            if (File.Exists("material.json"))
                materialConfig = JsonConvert.DeserializeObject(File.ReadAllText("material.json"));
            else
            {
                materialConfig = defaultConfig;
                File.WriteAllText("material.json", JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
            }
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
            ClearAllPictureBoxes(this.Controls);
            buttonSave.Enabled = pictureBoxBaseColor.ImageLocation != null;
        }

        private void ClearAllPictureBoxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is PictureBox pb)
                {
                    if (pb.Image != null)
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                    }
                    pb.ImageLocation = null;
                }
                // Rekursiv für Panels und andere Container
                if (control.HasChildren)
                {
                    ClearAllPictureBoxes(control.Controls);
                }
            }
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxBaseColor.ImageLocation == null)
            {
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
                            MessageBox.Show("Enter a valid resolution in the format 1024 * 1024", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
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
            Directory.CreateDirectory(gltf_output_dir);

            // Bitmap-Objekte erzeugen
            Bitmap col = new Bitmap(pictureBoxBaseColor.ImageLocation);

            // Neue Felder auslesen
            float[] baseColorTint = materialConfig.BaseColorTint ?? new float[] { 1.0f, 1.0f, 1.0f };
            string normalMapType = materialConfig.NormalMapType ?? "sobel";
            bool roughnessInvert = materialConfig.RoughnessInvert ?? false;
            float metallicIntensity = materialConfig.MetallicIntensity ?? 1.0f;
            float[] emissionColor = materialConfig.EmissionColor ?? new float[] { 1.0f, 1.0f, 1.0f };
            string alphaMode = materialConfig.AlphaMode ?? "opaque";

            // BaseColorTint anwenden
            ApplyBaseColorTint(col, baseColorTint);

            // NormalMapType verwenden
            Bitmap nrm;
            if (pictureBoxNormal.ImageLocation != null && File.Exists(pictureBoxNormal.ImageLocation))
            {
                nrm = new Bitmap(pictureBoxNormal.ImageLocation);
            }
            else
            {
                if (normalMapType == "sobel")
                    nrm = GenerateNormalMap(col, (float)materialConfig.NormalStrength);
                else
                    nrm = GenerateFlatNormal(col.Width, col.Height); // Beispiel für anderen Typ
            }

            // RoughnessInvert verwenden
            Bitmap bRoughness = GenerateRoughnessMap(col, (float)materialConfig.RoughnessStrength, roughnessInvert);

            // MetallicIntensity verwenden
            Bitmap bMetallic = GenerateMetallicMap(col, (int)materialConfig.MetallicThreshold, metallicIntensity);

            // EmissionColor verwenden
            Bitmap emission = GenerateEmissionMap(col, (float)materialConfig.EmissionStrength, emissionColor);
            Bitmap alpha = GenerateAlphaMap(col, (float)materialConfig.AlphaStrength);
            Bitmap bOcclusion = GenerateOcclusionMap(col, (float)materialConfig.OcclusionStrength);

            Bitmap nrmResized = nrm, bOcclusionResized = bOcclusion, bRoughnessResized = bRoughness, bMetallicResized = bMetallic, emissionResized = emission, alphaResized = alpha, colResized = col;
            if (resize)
            {
                nrmResized = ResizeImage(nrm, resizeX, resizeY);
                bOcclusionResized = ResizeImage(bOcclusion, resizeX, resizeY);
                bRoughnessResized = ResizeImage(bRoughness, resizeX, resizeY);
                bMetallicResized = ResizeImage(bMetallic, resizeX, resizeY);
                emissionResized = ResizeImage(emission, resizeX, resizeY);
                alphaResized = ResizeImage(alpha, resizeX, resizeY);
                colResized = ResizeImage(col, resizeX, resizeY);
            }

            // Speichern
            nrmResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_nrm.png"), System.Drawing.Imaging.ImageFormat.Png);
            bOcclusionResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_occ.png"), System.Drawing.Imaging.ImageFormat.Png);
            bRoughnessResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_rough.png"), System.Drawing.Imaging.ImageFormat.Png);
            bMetallicResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_metal.png"), System.Drawing.Imaging.ImageFormat.Png);
            emissionResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_emission.png"), System.Drawing.Imaging.ImageFormat.Png);
            alphaResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_alpha.png"), System.Drawing.Imaging.ImageFormat.Png);
            colResized.Save(Path.Combine(gltf_output_dir, textBoxMaterialName.Text + "_col.png"), System.Drawing.Imaging.ImageFormat.Png);

            // Dispose der ggf. neu erzeugten Bitmaps
            if (resize)
            {
                nrmResized.Dispose();
                bOcclusionResized.Dispose();
                bRoughnessResized.Dispose();
                bMetallicResized.Dispose();
                emissionResized.Dispose();
                alphaResized.Dispose();
                colResized.Dispose();
            }

            // Dispose der Original-Bitmaps
            nrm.Dispose();
            bOcclusion.Dispose();
            bRoughness.Dispose();
            bMetallic.Dispose();
            emission.Dispose();
            alpha.Dispose();
            col.Dispose();

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
                using (Bitmap emissionBmp = new Bitmap(pictureBoxEmission.ImageLocation))
                {
                    Bitmap emissionBmpResized = emissionBmp;
                    if (resize) emissionBmpResized = ResizeImage(emissionBmp, resizeX, resizeY);
                    emissionBmpResized.Save(emission_file_path_local);
                    if (resize) emissionBmpResized.Dispose();
                }
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
            Bitmap normalMap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

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
        private Bitmap GenerateOcclusionMap(Bitmap albedo, float strength = 1.0f)
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
        private Bitmap GenerateRoughnessMap(Bitmap albedo, float effectStrength, bool invert)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap rough = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int gray = (int)(((c.R + c.G + c.B) / 3) * effectStrength);
                    if (invert) gray = 255 - gray;
                    rough.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            return rough;
        }

        // Metallic aus Albedo (Helligkeit, optional Schwellenwert)
        private Bitmap GenerateMetallicMap(Bitmap albedo, int threshold, float intensity)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap metal = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    int value = gray > threshold ? (int)(255 * intensity) : 0;
                    metal.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            return metal;
        }

        // Emission aus Albedo (optional: Helligkeit, hier einfach übernommen)
        private Bitmap GenerateEmissionMap(Bitmap albedo, float strength, float[] emissionColor)
        {
            int width = albedo.Width;
            int height = albedo.Height;
            Bitmap emission = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = albedo.GetPixel(x, y);
                    int r = Math.Min(255, (int)(c.R * emissionColor[0] * strength));
                    int g = Math.Min(255, (int)(c.G * emissionColor[1] * strength));
                    int b = Math.Min(255, (int)(c.B * emissionColor[2] * strength));
                    emission.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            return emission;
        }

        // Alpha aus Albedo (optional: Helligkeit, hier voll transparent)
        private Bitmap GenerateAlphaMap(Bitmap albedo, float strength = 1.0f)
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

        /// <summary>
        /// Wendet einen Farb-Tint auf das gegebene Bitmap an.
        /// </summary>
        /// <param name="bitmap">Das zu bearbeitende Bitmap.</param>
        /// <param name="tint">Ein Array mit drei float-Werten für R, G, B (z.B. {1.0f, 1.0f, 1.0f}).</param>
        private void ApplyBaseColorTint(Bitmap bitmap, float[] tint)
        {
            if (tint == null || tint.Length != 3) return;
            int width = bitmap.Width;
            int height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = bitmap.GetPixel(x, y);
                    int r = Math.Min(255, (int)(c.R * tint[0]));
                    int g = Math.Min(255, (int)(c.G * tint[1]));
                    int b = Math.Min(255, (int)(c.B * tint[2]));
                    bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
        }
    }
}
