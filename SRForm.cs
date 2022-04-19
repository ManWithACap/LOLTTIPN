using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace LOLTTIPN
{
    public partial class SRForm : Form
    {
        public static string currentRunepage; //name of current "page" that the form is on (runepages, champs, items, etc.)
        public static SRForm srform;
        ChampionsData ChampionsData = new ChampionsData(); //ChampionsData variable for JSON classes in the RiotAPI
        ItemsData ItemsData = new ItemsData(); //ItemsData variable for JSON classes in the RiotAPI
        RunesData RunesData = new RunesData(); //RunesData variable for JSON classes in the RiotAPI
        Button NewPageButton; //specific button used in the "Runepages" page that will create a new runepage for the user
        private string item3330location = ""; //there's one single item (fiddlesticks' reworked trinket) that is excessively large. this one just gets the location of that image and resizes it later
        private bool mouseDown; //you've seen this before in MenuForm
        private Point lastLocation; //you've seen this before in MenuForm
        private List<bool> Actives = new List<bool>() //a system of determining which "pages" are active so that they don't interfere with each other when one is active and another is clicked
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        };

        //constructor stuff
        public SRForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            srform = this;
        }

        //literally nothing
        private void SRForm_Load(object sender, EventArgs e)
        {

        }

        //i never used this but i keep it here just in case cuz it's nice to have a blur effect available for whatever
        private static Bitmap Blur(Bitmap image, Int32 blurSize)
        {
            return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }

        //i really forgot why this is here and also named "Blur"
        //tbh i just copied these from the internet somewhere a while ago and i just abandoned it
        private unsafe static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // Lock the bitmap's bits
            BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);

            // Get bits per pixel for current PixelFormat
            int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);

            // Get pointer to first line
            byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

            // look at every pixel in the blur rectangle
            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            avgB += data[0]; // Blue
                            avgG += data[1]; // Green
                            avgR += data[2]; // Red

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                    {
                        for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            // Change values
                            data[0] = (byte)avgB;
                            data[1] = (byte)avgG;
                            data[2] = (byte)avgR;
                        }
                    }
                }
            }

            // Unlock the bits
            blurred.UnlockBits(blurredData);

            return blurred;
        }

        //yup
        private void SRForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        //yup
        private void SRForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        //yup
        private void SRForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //you ever get tired of commenting?
        private void maxiButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            maxiButton.ForeColor = Color.Goldenrod;
        }

        //yup
        private void miniButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            miniButton.ForeColor = Color.Goldenrod;
        }

        //yup
        private void maxiButton_MouseDown(object sender, MouseEventArgs e)
        {
            maxiButton.ForeColor = Color.Blue;
        }

        //yup
        private void exitButton_MouseDown(object sender, MouseEventArgs e)
        {
            exitButton.ForeColor = Color.Blue;
        }

        //yup
        private void miniButton_MouseDown(object sender, MouseEventArgs e)
        {
            miniButton.ForeColor = Color.Blue;
        }

        //yup
        private void exitButton_Click(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Goldenrod;
            DialogResult exitResult = MessageBox.Show("Are you sure you want to exit LOLTTIPN?", "Exit Confirm", MessageBoxButtons.YesNo);
            if (exitResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //yup
        private void SRForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm MenuForm = (MenuForm)Application.OpenForms["MenuForm"];
            MenuForm.Close();
        }

        //ok now we got useful shit
        //just a standard onhover call to change the "border" to blue
        private void championImage_MouseEnter(object sender, EventArgs e)
        {
            var obj = sender as PictureBox;
            obj.BackColor = Color.Blue;
        }

        //mouseleave event to reverse the onhover opposite function
        private void championImage_MouseLeave(object sender, EventArgs e)
        {
            var obj = sender as PictureBox;
            obj.BackColor = Color.Goldenrod;
        }

        //onclick for the boxes of the champion icons in the "Champions" page
        private void championsButton_Click(object sender, EventArgs e)
        {
            nameSearchBar.Text = "";
            nameSearchBar.Visible = true;
            for (var i = 0; i < Actives.Count(); i++)
            {
                if (i != 0)
                {
                    Actives[i] = false;
                }
            }
            FlowLayoutPanel.Controls.Clear();
            if (Actives[0] == false)
            {
                foreach (var file in Directory.GetFiles("./selfdata/loldata/patch/img/champion/"))
                {
                    string championName = file.Replace("./selfdata/loldata/patch/img/champion/", "").Replace(".png", "");
                    PictureBox champImage = new PictureBox();
                    champImage.Image = new Bitmap(file);
                    champImage.Cursor = Cursors.Hand;
                    champImage.SizeMode = PictureBoxSizeMode.Zoom;
                    champImage.Click += new EventHandler(championImage_Click);
                    champImage.MouseEnter += new EventHandler(championImage_MouseEnter);
                    champImage.MouseLeave += new EventHandler(championImage_MouseLeave);
                    champImage.BackColor = Color.Goldenrod;
                    champImage.Margin = new Padding(2);
                    champImage.Padding = new Padding(10);
                    champImage.SizeMode = PictureBoxSizeMode.AutoSize;
                    champImage.ImageLocation = "./selfdata/loldata/patch/img/champion/" + championName + ".png";
                    FlowLayoutPanel.Controls.Add(champImage);
                }
                Actives[0] = true;
            }

        }

        //mousedown event for the page buttons i think
        private void SRButtons_MouseDown(object sender, MouseEventArgs e)
        {
            var obj = sender as Button;
            obj.BackColor = Color.White;
        }

        //mouseup yada yada
        private void SRButtons_MouseUp(object sender, MouseEventArgs e)
        {
            var obj = sender as Button;
            obj.BackColor = Color.FromArgb(0, 64, 64);
        }

        //resize image helper function for champion images and whatnot (also used for the fiddle item that's hilariously large)
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

        
        private void championImage_Click(object sender, EventArgs e)
        {
            var obj = sender as PictureBox;
            string championName = obj.ImageLocation.Replace("./selfdata/loldata/patch/img/champion/", "").Replace(".png", "");

            ChampionPageForm cpf = new ChampionPageForm(this, championName);
            cpf.Show();
        }

        //searchbar called event ontextchange; it's quite large...
        private void nameSearchBar_TextChanged(object sender, EventArgs e)
        {
            if(Actives[0] == true)
            {

                FlowLayoutPanel.Controls.Clear();
                foreach (var file in Directory.GetFiles("./selfdata/loldata/patch/img/champion/"))
                {
                    var obj = sender as TextBox;
                    string championName = file.Replace("./selfdata/loldata/patch/img/champion/", "").Replace(".png", "");
                    string name = championName.ToLower();
                    if (name.Contains(obj.Text.ToLower()))
                    {
                        PictureBox champImage = new PictureBox();
                        champImage.Image = new Bitmap(file);
                        champImage.Cursor = Cursors.Hand;
                        champImage.SizeMode = PictureBoxSizeMode.Zoom;
                        champImage.Click += new EventHandler(championImage_Click);
                        champImage.MouseEnter += new EventHandler(championImage_MouseEnter);
                        champImage.MouseLeave += new EventHandler(championImage_MouseLeave);
                        champImage.BackColor = Color.Goldenrod;
                        champImage.Margin = new Padding(2);
                        champImage.Padding = new Padding(10);
                        champImage.SizeMode = PictureBoxSizeMode.AutoSize;
                        champImage.ImageLocation = "./selfdata/loldata/patch/img/champion/" + championName + ".png";
                        FlowLayoutPanel.Controls.Add(champImage);
                    }
                }
            }
            else if (Actives[1] == true)
            {
                Button newpagebutton = this.addPageButton;
                FlowLayoutPanel.Controls.Clear();
                FlowLayoutPanel.Controls.Add(newpagebutton);
                foreach (var file in Directory.GetFiles("./selfdata/runepages/" + MenuForm.currentUser))
                {
                    var obj = sender as TextBox;
                    string[] filelines = File.ReadAllLines(file);
                    if (filelines[0].ToLower().Contains(obj.Text.ToLower()))
                    {
                        NewPageButton = new Button();
                        NewPageButton.Click += NewPageButton_Click;
                        NewPageButton.FlatAppearance.BorderColor = Color.LightGray;
                        NewPageButton.FlatAppearance.BorderSize = 5;
                        NewPageButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
                        NewPageButton.FlatAppearance.MouseOverBackColor = Color.Teal;
                        NewPageButton.Width = addPageButton.Width;
                        NewPageButton.Height = addPageButton.Height;
                        NewPageButton.FlatStyle = FlatStyle.Flat;
                        NewPageButton.Margin = new Padding(20);
                        NewPageButton.Cursor = Cursors.Hand;
                        NewPageButton.Text = filelines[0];
                        NewPageButton.Font = new Font("Lucida Fax", 20, FontStyle.Bold);

                        ApplyChampArt(NewPageButton);
                        FlowLayoutPanel.Controls.Add(NewPageButton);
                    }
                }
            }
        }

        //runepages button click event to change flowlayout items to runepages and stuff
        private void runepagesButton_Click(object sender, EventArgs e)
        {
            rphelper();
        }

        public void rphelper()
        {
            nameSearchBar.Text = "";
            nameSearchBar.Visible = true;
            for (var i = 0; i < Actives.Count(); i++)
            {
                if (i != 1)
                {
                    Actives[i] = false;
                }
            }
            Actives[1] = true;
            FlowLayoutPanel.Controls.Clear();
            if (Actives[1] == true)
            {
                addPageButton.Visible = true;
                FlowLayoutPanel.Controls.Add(addPageButton);


                //add player-made pages and add button
                foreach (var page in Directory.GetFiles("./selfdata/runepages/" + MenuForm.currentUser))
                {
                    string[] filelines = File.ReadAllLines(page);
                    Console.WriteLine(page);
                    NewPageButton = new Button();
                    NewPageButton.Click += NewPageButton_Click;
                    NewPageButton.MouseEnter += NewPageButton_Enter;
                    NewPageButton.MouseLeave += NewPageButton_Leave;
                    NewPageButton.FlatAppearance.BorderColor = Color.LightGray;
                    NewPageButton.FlatAppearance.BorderSize = 5;
                    NewPageButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
                    NewPageButton.FlatAppearance.MouseOverBackColor = Color.Teal;
                    NewPageButton.Width = addPageButton.Width;
                    NewPageButton.Height = addPageButton.Height;
                    NewPageButton.FlatStyle = FlatStyle.Flat;
                    NewPageButton.Margin = new Padding(20);
                    NewPageButton.Cursor = Cursors.Hand;
                    NewPageButton.Text = filelines[0];
                    NewPageButton.Font = new Font("Lucida Fax", 20, FontStyle.Underline);

                    ApplyChampArt(NewPageButton);
                    FlowLayoutPanel.Controls.Add(NewPageButton);
                }
            }
        }

        //used to open a runepage form for the runepage button
        private void NewPageButton_Click(object sender, EventArgs e)
        {
            RunePageForm rpg = new RunePageForm();
            Button obj = sender as Button;
            currentRunepage = obj.Text;
            rpg.Show();
        }

        private void NewPageButton_Enter(object sender, EventArgs e)
        {
            Button obj = sender as Button;
            obj.FlatAppearance.BorderColor = Color.Blue;
        }

        private void NewPageButton_Leave(object sender, EventArgs e)
        {
            Button obj = sender as Button;
            obj.FlatAppearance.BorderColor = Color.LightGray;
        }

        //runepage add button onclick event; creates a file and button just like all the others
        private void addPageButton_Click(object sender, EventArgs e)
        {
            NewPageButton = new Button();
            NewPageButton.Click += NewPageButton_Click;
            NewPageButton.MouseEnter += NewPageButton_Enter;
            NewPageButton.MouseLeave += NewPageButton_Leave;
            NewPageButton.FlatAppearance.BorderColor = Color.LightGray;
            NewPageButton.FlatAppearance.BorderSize = 5;
            NewPageButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            NewPageButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            NewPageButton.Width = addPageButton.Width;
            NewPageButton.Height = addPageButton.Height;
            NewPageButton.FlatStyle = FlatStyle.Flat;
            NewPageButton.Margin = new Padding(20);
            NewPageButton.Cursor = Cursors.Hand;
            NewPageButton.Text = "New Runepage";
            NewPageButton.Font = new Font("Lucida Fax", 20, FontStyle.Bold);

            File.WriteAllText("./selfdata/runepages/" + MenuForm.currentUser + "/" + NewPageButton.Text + ".runespage", 
                NewPageButton.Text + "\n" +
                "Sorcery\n" +
                "SummonAery\n" +
                "ManaflowBand\n" +
                "Transcendence\n" +
                "GatheringStorm\n" +
                "Precision\n" +
                "PresenceOfMind\n" +
                "blank\n" +
                "CutDown\n" +
                "StatModsAdaptiveForce\n" +
                "StatModsAdaptiveForce\n" +
                "StatModsHealthScaling\n");
            ApplyChampArt(NewPageButton);
            FlowLayoutPanel.Controls.Add(NewPageButton);
        }

        //this is sort of an easter egg used for a small artistic thing players can do.
        //if they use a champion's name in their runepage name, it will give the button an image of that champ
        private void ApplyChampArt(Button button)
        {
            foreach (var image in Directory.GetFiles("./selfdata/loldata/patch/img/champion/"))
            {
                string imageName = Path.GetFileName(image).Replace(".png", "");
                if (button.Text.ToUpper().Contains(imageName.ToUpper()))
                {
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.BackgroundImage = new Bitmap(image);
                }
            }
        }
    }
}
