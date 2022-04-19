using RiotSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLTTIPN
{
    public partial class ChampionPageForm : Form
    {
        ChampionsData ChampionsData = new ChampionsData();
        private string championName;
        private bool mouseDown;
        private Point lastLocation;

        public ChampionPageForm()
        {
            InitializeComponent();
        }

        private SRForm thisParent = null;
        public ChampionPageForm(Form parentForm, string champName)
        {
            this.championName = champName;
            thisParent = parentForm as SRForm;
            InitializeComponent();
        }

        private void ChampionPageForm_Load(object sender, EventArgs e)
        {
            champName.Text = ChampionsData.root.data[championName].name;
            champTitle.Text = '"' + ChampionsData.root.data[championName].title + '"';
            champPic.Image = new Bitmap("./selfdata/loldata/img/champion/splash/" + ChampionsData.root.data[championName].id + "_0.jpg");
            champLore.Text = ChampionsData.root.data[championName].lore;
            switch (ChampionsData.root.data[championName].tags[0])
            {
                case "Fighter":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Fighter_icon.png");
                    break;
                case "Mage":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Mage_icon.png");
                    break;
                case "Marksman":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Marksman_icon.png");
                    break;
                case "Assassin":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Slayer_icon.png");
                    break;
                case "Tank":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Tank_icon.png");
                    break;
                case "Support":
                    champRole.Text = ChampionsData.root.data[championName].tags[0];
                    champRolePic.Image = new Bitmap("./selfdata/images/role images/Controller_icon.png");
                    break;
            }
            if (ChampionsData.root.data[championName].tags.Count() > 1)
            {
                switch (ChampionsData.root.data[championName].tags[1])
                {
                    case "Fighter":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Fighter_icon.png");
                        break;
                    case "Mage":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Mage_icon.png");
                        break;
                    case "Marksman":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Marksman_icon.png");
                        break;
                    case "Assassin":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Slayer_icon.png");
                        break;
                    case "Tank":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Tank_icon.png");
                        break;
                    case "Support":
                        champSubRole.Text = ChampionsData.root.data[championName].tags[1];
                        champSubRolePic.Image = new Bitmap("./selfdata/images/role images/Controller_icon.png");
                        break;
                }
            }
            else
            {
                champSubRole.Hide();
                champSubRolePic.Hide();
            }

            var api = RiotApi.GetDevelopmentInstance("RGAPI-e107e2be-1b3a-40dc-8161-d0e2b54f32c6");
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Na, "XRES Cappy").Result;
                Console.WriteLine(summoner.Level);
            }
            catch (RiotSharpException ex)
            {
                //eh
            }
        }   

        //yup
        private void CPFForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        //yup
        private void CPFForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        //yup
        private void CPFForm_MouseUp(object sender, MouseEventArgs e)
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
            DialogResult exitResult = MessageBox.Show("Are you sure you want to close this Champion Information Page?", "Exit Confirm", MessageBoxButtons.YesNo);
            if (exitResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
