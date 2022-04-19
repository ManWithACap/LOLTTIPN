using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace LOLTTIPN
{
    public partial class RunePageForm : Form
    {
        string[] file; //string array of each file line in a .runepage file (current file lines though)
        RunesData RunesData = new RunesData(); //runesdata JSON classes variable
        private bool mouseDown; //yup
        private Point lastLocation; //yup
        string[] edited;
        PictureBox previous1;
        PictureBox previous2;
        PictureBox previous3;


        //MASSIVE LIST OF LISTS
        //USED TO ITERATE THROUGH EVERY IMAGE ON THE FORM; THIS WAS SO PAINFUL TO FIGURE OUT HOW TO DO
        private List<Label> StatModsDescs = new List<Label>();
        private List<PictureBox> t1rune1 = new List<PictureBox>();
        private List<PictureBox> t1rune2 = new List<PictureBox>();
        private List<PictureBox> t1rune3 = new List<PictureBox>();
        private List<PictureBox> t1rune4 = new List<PictureBox>();
        private List<PictureBox> t2rune1 = new List<PictureBox>();
        private List<PictureBox> t2rune2 = new List<PictureBox>();
        private List<PictureBox> t2rune3 = new List<PictureBox>();
        private List<PictureBox> tree1 = new List<PictureBox>();
        private List<PictureBox> tree2 = new List<PictureBox>();
        private List<PictureBox> statmod1 = new List<PictureBox>();
        private List<PictureBox> statmod2 = new List<PictureBox>();
        private List<PictureBox> statmod3 = new List<PictureBox>();

        private List<List<PictureBox>> MASTERLIST = new List<List<PictureBox>>();
        //-------------------------------------------------
        //-------------------------------------------------
        private Dictionary<PictureBox, string> PictBoxRunesNames = new Dictionary<PictureBox, string>();
        private Dictionary<PictureBox, string> PictBoxTrees1Names = new Dictionary<PictureBox, string>();
        private Dictionary<PictureBox, string> PictBoxTrees2Names = new Dictionary<PictureBox, string>();

        private Dictionary<PictureBox, string> statmod1images = new Dictionary<PictureBox, string>();
        private Dictionary<PictureBox, string> statmod2images = new Dictionary<PictureBox, string>();
        private Dictionary<PictureBox, string> statmod3images = new Dictionary<PictureBox, string>();

        //YUP
        public RunePageForm()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        //this load event is pretty big because it changes every image according to the runes used in the current file (file[x])
        private void RunePageForm_Load(object sender, EventArgs args)
        {
            file = File.ReadAllLines("./selfdata/runepages/" + MenuForm.currentUser + "/" + SRForm.currentRunepage + ".runespage");
            edited = file;

            PageTitle.Text = file[0];

            statmod1images.Add(statmod1image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
            statmod1images.Add(statmod1image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsAttackSpeedIcon.png");
            statmod1images.Add(statmod1image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsCDRScalingIcon.png");

            statmod2images.Add(statmod2image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
            statmod2images.Add(statmod2image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
            statmod2images.Add(statmod2image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");

            statmod3images.Add(statmod3image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsHealthScalingIcon.png");
            statmod3images.Add(statmod3image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
            statmod3images.Add(statmod3image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");


            //foreach control, if control is a picturebox, give it the click event function for them all
            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(PictureBox))
                {
                    PictureBox ImageBox = (PictureBox)control;
                    ImageBox.Cursor = Cursors.Hand;
                    ImageBox.Click += runeorstat_Click;
                    ImageBox.MouseEnter += ImageBox_MouseEnter;
                    ImageBox.MouseLeave += ImageBox_MouseLeave;
                    ImageBox.Image = Grayscale(new Bitmap(ImageBox.Image));
                    ImageBox.BorderStyle = BorderStyle.None;
                    ImageBox.BackColor = Color.FromArgb(50, Color.White);
                    ImageBox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 100, 100, 30, 30));
                }
            }// foreach control, if control is a label, set the corresponding description of the rune in file from the JSON classes
            //i go by a system:
            /* so basically it works like this
             * runetree1
             * tree1runes 1-4
             * 
             * runetree2
             * tree2runes 1-3
             * 
             * statmods 1-3
             * 
             * descriptions are just in the same spots as the treeXrunes
             */
            //basically the system goes down the list of runes from first to last :)
            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    Label label = (Label)control;
                    switch (label.Name)
                    {
                        case "keystoneTitle":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[2])
                                            {
                                                keystoneTitle.Text = rune.name;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "keystoneDesc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[2])
                                            {
                                                keystoneDesc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[2] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune2desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[3])
                                            {
                                                t1rune2desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[3] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune3desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[4])
                                            {
                                                t1rune3desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[4] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune4desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[5])
                                            {
                                                t1rune4desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[5] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune1desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[7])
                                            {
                                                t2rune1desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[7] == "blank")
                                            {
                                                t2rune1desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune2desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[8])
                                            {
                                                t2rune2desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[8] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune3desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == file[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == file[9])
                                            {
                                                t2rune3desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (file[9] == "blank")
                                            {
                                                t2rune3desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    if (label.Name.Contains("statmod") && label.Name.Contains("desc"))
                    {
                        StatModsDescs.Add(label);
                    }
                }

                //the start of the excruciating amount of loops and inception bullshit of setting images from 3 to 4 dimensional arrays without even knowing what element you want specifically so you then have to make more loops and bullshit to use if statements and shit to get specific items from the list in the JSON omg i hate json fucking hell aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                if (control.GetType() == typeof(PictureBox))
                {
                    PictureBox picture = (PictureBox)control;
                    if (picture.Name.Contains("t1rune1image"))
                    {
                        t1rune1.Add(picture);
                        t1rune1.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune2image"))
                    {
                        t1rune2.Add(picture);
                        t1rune2.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune3image"))
                    {
                        t1rune3.Add(picture);
                        t1rune3.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune4image"))
                    {
                        t1rune4.Add(picture);
                        t1rune4.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune1image"))
                    {
                        t2rune1.Add(picture);
                        t2rune1.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune2image"))
                    {
                        t2rune2.Add(picture);
                        t2rune2.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune3image"))
                    {
                        t2rune3.Add(picture);
                        t2rune3.Reverse();
                    }
                    else if (picture.Name.Contains("statmod1image"))
                    {
                        statmod1.Add(picture);
                    }
                    else if (picture.Name.Contains("statmod2image"))
                    {
                        statmod2.Add(picture);
                    }
                    else if (picture.Name.Contains("statmod3image"))
                    {
                        statmod3.Add(picture);
                    }
                    else if (picture.Name.Contains("tree1image"))
                    {
                        tree1.Add(picture);
                    }
                    else if (picture.Name.Contains("tree2image"))
                    {
                        tree2.Add(picture);
                    }


                }
            }


            //oh god another string of JSON bullshit i had to spend weeks on aaaaaaaaaaaaaaaaaaaaaa
            foreach (RunesData.Category category in RunesData.root)
            {
                if (category.key == file[1])
                {
                    for (int i = 0; i < category.slots.Count(); i++)
                    {
                        switch (i)
                        {
                            case 0:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[2])
                                    {
                                        t1rune1[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        Bitmap bm = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                        t1rune1[j].Image = bm;
                                    }

                                    PictBoxRunesNames.Add(t1rune1[j], category.slots[i].runes[j].key);

                                    if (category.key != "Domination" && category.key != "Precision")
                                    {
                                        t1rune1[3].Hide();
                                    }
                                    else
                                    {
                                        t1rune1[3].Show();
                                    }
                                }
                                break;
                            case 1:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[3])
                                    {
                                        t1rune2[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune2[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune2[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 2:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[4])
                                    {
                                        t1rune3[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune3[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune3[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 3:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[5])
                                    {
                                        t1rune4[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune4[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune4[j], category.slots[i].runes[j].key);

                                    if (category.key != "Domination")
                                    {
                                        t1rune4[3].Hide();
                                    }
                                    else
                                    {
                                        t1rune4[3].Show();
                                    }
                                }
                                break;
                        }
                    }
                }
                else if (category.key == file[6])
                {
                    for (int i = 0; i < category.slots.Count(); i++)
                    {
                        switch (i)
                        {

                            case 1:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[7])
                                    {
                                        t2rune1[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune1[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t2rune1[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 2:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[8])
                                    {
                                        t2rune2[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune2[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t2rune2[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 3:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == file[9])
                                    {
                                        t2rune3[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune3[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    if (category.key != "Domination")
                                    {
                                        t2rune3[t2rune3.Count() - 1].Hide();
                                    }
                                    else
                                    {
                                        t2rune3[t2rune3.Count() - 1].Show();
                                    }

                                    PictBoxRunesNames.Add(t2rune3[j], category.slots[i].runes[j].key);
                                }
                                break;
                        }
                    }
                }
            }

            int counter = 0;
            foreach (RunesData.Category category in RunesData.root)
            {
                tree1[counter].Image = new Bitmap("./selfdata/loldata/img/" + category.icon);
                tree2[counter].Image = new Bitmap("./selfdata/loldata/img/" + category.icon);
                if (category.key != file[1])
                {
                    tree1[counter].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.icon));
                }


                if (category.key != file[6])
                {
                    tree2[counter].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.icon));
                }
                PictBoxTrees1Names.Add(tree1[counter], category.key);
                PictBoxTrees2Names.Add(tree2[counter], category.key);
                counter++;
            }

            foreach (PictureBox pictureBox in statmod1)
            {
                if (edited[10] == "StatModsAttackSpeed")
                {//middle
                    statmod1[1].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAttackSpeedIcon.png");
                    statmod1[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png"));
                    statmod1[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsCDRScalingIcon.png"));
                    statmod1[1].BackColor = Color.FromArgb(50, Color.Black);
                    previous1 = statmod1[1];
                }
                else if (edited[10] == "StatModsAdaptiveForce")
                {//left
                    statmod1[0].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
                    statmod1[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAttackSpeedIcon.png"));
                    statmod1[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsCDRScalingIcon.png"));
                    statmod1[0].BackColor = Color.FromArgb(50, Color.Black);
                    previous1 = statmod1[0];
                }
                else if (edited[10] == "StatModsCDRScaling")
                {//right
                    statmod1[2].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsCDRScalingIcon.png");
                    statmod1[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png"));
                    statmod1[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAttackSpeedIcon.png"));
                    statmod1[2].BackColor = Color.FromArgb(50, Color.Black);
                    previous1 = statmod1[2];
                }
            }

            foreach (PictureBox pictureBox in statmod2)
            {
                if (edited[11] == "StatModsAdaptiveForce")
                {//left
                    statmod2[0].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
                    statmod2[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png"));
                    statmod2[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png"));
                    statmod2[0].BackColor = Color.FromArgb(50, Color.Black);
                    previous2 = statmod2[0];
                }
                else if (edited[11] == "StatModsArmor")
                {//middle
                    statmod2[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png"));
                    statmod2[1].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
                    statmod2[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png"));
                    statmod2[1].BackColor = Color.FromArgb(50, Color.Black);
                    previous2 = statmod2[1];
                }
                else if (edited[11] == "StatModsMagicRes")
                {//right
                    statmod2[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png"));
                    statmod2[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png"));
                    statmod2[2].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");
                    statmod2[2].BackColor = Color.FromArgb(50, Color.Black);
                    previous2 = statmod2[2];
                }
            }

            foreach (PictureBox pictureBox in statmod3)
            {
                if (edited[12] == "StatModsHealthScaling")
                {//left
                    statmod3[0].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsHealthScalingIcon.png");
                    statmod3[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png"));
                    statmod3[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png"));
                    statmod3[0].BackColor = Color.FromArgb(50, Color.Black);
                    previous3 = statmod3[0];
                }
                else if (edited[12] == "StatModsArmor")
                {//middle
                    statmod3[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsHealthScalingIcon.png"));
                    statmod3[1].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
                    statmod3[2].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png"));
                    statmod3[1].BackColor = Color.FromArgb(50, Color.Black);
                    previous3 = statmod3[1];
                }
                else if (edited[12] == "StatModsMagicRes")
                {//right
                    statmod3[0].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsHealthScalingIcon.png"));
                    statmod3[1].Image = Grayscale(new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png"));
                    statmod3[2].Image = new Bitmap("./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");
                    statmod3[2].BackColor = Color.FromArgb(50, Color.Black);
                    previous3 = statmod3[2];
                }
            }

            MASTERLIST.Add(tree1);
            MASTERLIST.Add(t1rune1);
            MASTERLIST.Add(t1rune2);
            MASTERLIST.Add(t1rune3);
            MASTERLIST.Add(t1rune4);
            MASTERLIST.Add(tree2);
            MASTERLIST.Add(t2rune1);
            MASTERLIST.Add(t2rune2);
            MASTERLIST.Add(t2rune3);
            MASTERLIST.Add(statmod1);
            MASTERLIST.Add(statmod2);
            MASTERLIST.Add(statmod3);

        }

        public void ReloadRunepage()
        {
            MASTERLIST.Clear();
            tree1.Clear();
            t1rune1.Clear();
            t1rune2.Clear();
            t1rune3.Clear();
            t1rune4.Clear();
            tree2.Clear();
            t2rune1.Clear();
            t2rune2.Clear();
            t2rune3.Clear();
            StatModsDescs.Clear();
            PictBoxRunesNames.Clear();
            PictBoxTrees1Names.Clear();
            PictBoxTrees2Names.Clear();
            statmod1images.Clear();
            statmod2images.Clear();
            statmod3images.Clear();
            statmod1images.Clear();
            statmod2images.Clear();
            statmod3images.Clear();

            statmod1images.Add(statmod1image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
            statmod1images.Add(statmod1image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsAttackSpeedIcon.png");
            statmod1images.Add(statmod1image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsCDRScalingIcon.png");

            statmod2images.Add(statmod2image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsAdaptiveForceIcon.png");
            statmod2images.Add(statmod2image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
            statmod2images.Add(statmod2image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");

            statmod3images.Add(statmod3image3, "./selfdata/loldata/img/perk-images/StatMods/StatModsHealthScalingIcon.png");
            statmod3images.Add(statmod3image2, "./selfdata/loldata/img/perk-images/StatMods/StatModsArmorIcon.png");
            statmod3images.Add(statmod3image1, "./selfdata/loldata/img/perk-images/StatMods/StatModsMagicResIcon.png");


            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    Label label = (Label)control;
                    switch (label.Name)
                    {
                        case "keystoneTitle":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[2])
                                            {
                                                keystoneTitle.Text = rune.name;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "keystoneDesc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[2])
                                            {
                                                keystoneDesc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[2] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune2desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[3])
                                            {
                                                t1rune2desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[3] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune3desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[4])
                                            {
                                                t1rune3desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[4] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t1rune4desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[1])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[5])
                                            {
                                                t1rune4desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[5] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune1desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[7])
                                            {
                                                t2rune1desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[7] == "blank")
                                            {
                                                t2rune1desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune2desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[8])
                                            {
                                                t2rune2desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[8] == "blank")
                                            {
                                                t2rune2desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "t2rune3desc":
                            foreach (RunesData.Category category in RunesData.root)
                            {
                                if (category.key == edited[6])
                                {
                                    foreach (RunesData.Slot slot in category.slots)
                                    {
                                        foreach (RunesData.Rune rune in slot.runes)
                                        {
                                            if (rune.key == edited[9])
                                            {
                                                t2rune3desc.Text = Regex.Replace(rune.shortDesc, "<.*?>", String.Empty);
                                            }
                                            else if (edited[9] == "blank")
                                            {
                                                t2rune3desc.Text = "----------";
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    if (label.Name.Contains("statmod") && label.Name.Contains("desc"))
                    {
                        StatModsDescs.Add(label);
                    }
                }

                //the start of the excruciating amount of loops and inception bullshit of setting images from 3 to 4 dimensional arrays without even knowing what element you want specifically so you then have to make more loops and bullshit to use if statements and shit to get specific items from the list in the JSON omg i hate json fucking hell aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                if (control.GetType() == typeof(PictureBox))
                {
                    PictureBox picture = (PictureBox)control;
                    if (picture.Name.Contains("t1rune1image"))
                    {
                        t1rune1.Add(picture);
                        t1rune1.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune2image"))
                    {
                        t1rune2.Add(picture);
                        t1rune2.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune3image"))
                    {
                        t1rune3.Add(picture);
                        t1rune3.Reverse();
                    }
                    else if (picture.Name.Contains("t1rune4image"))
                    {
                        t1rune4.Add(picture);
                        t1rune4.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune1image"))
                    {
                        t2rune1.Add(picture);
                        t2rune1.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune2image"))
                    {
                        t2rune2.Add(picture);
                        t2rune2.Reverse();
                    }
                    else if (picture.Name.Contains("t2rune3image"))
                    {
                        t2rune3.Add(picture);
                        t2rune3.Reverse();
                    }
                    else if (picture.Name.Contains("statmod1image"))
                    {
                        statmod1.Add(picture);
                    }
                    else if (picture.Name.Contains("statmod2image"))
                    {
                        statmod2.Add(picture);
                    }
                    else if (picture.Name.Contains("statmod3image"))
                    {
                        statmod3.Add(picture);
                    }
                    else if (picture.Name.Contains("tree1image"))
                    {
                        tree1.Add(picture);
                    }
                    else if (picture.Name.Contains("tree2image"))
                    {
                        tree2.Add(picture);
                    }


                }
            }


            //oh god another string of JSON bullshit i had to spend weeks on aaaaaaaaaaaaaaaaaaaaaa
            foreach (RunesData.Category category in RunesData.root)
            {
                if (category.key == edited[1])
                {
                    for (int i = 0; i < category.slots.Count(); i++)
                    {
                        switch (i)
                        {
                            case 0:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[2])
                                    {
                                        t1rune1[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        Bitmap bm = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                        t1rune1[j].Image = bm;
                                    }

                                    PictBoxRunesNames.Add(t1rune1[j], category.slots[i].runes[j].key);

                                    if (category.key != "Domination" && category.key != "Precision")
                                    {
                                        t1rune1[3].Hide();
                                    }
                                    else
                                    {
                                        t1rune1[3].Show();
                                    }
                                }
                                break;
                            case 1:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[3])
                                    {
                                        t1rune2[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune2[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune2[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 2:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[4])
                                    {
                                        t1rune3[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune3[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune3[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 3:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[5])
                                    {
                                        t1rune4[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t1rune4[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t1rune4[j], category.slots[i].runes[j].key);

                                    if (category.key != "Domination")
                                    {
                                        t1rune4[3].Hide();
                                    }
                                    else
                                    {
                                        t1rune4[3].Show();
                                    }
                                }
                                break;
                        }
                    }
                }
                else if (category.key == edited[6])
                {
                    for (int i = 0; i < category.slots.Count(); i++)
                    {
                        switch (i)
                        {

                            case 1:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[7])
                                    {
                                        t2rune1[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune1[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t2rune1[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 2:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[8])
                                    {
                                        t2rune2[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune2[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    PictBoxRunesNames.Add(t2rune2[j], category.slots[i].runes[j].key);
                                }
                                break;
                            case 3:
                                for (int j = 0; j < category.slots[i].runes.Count(); j++)
                                {
                                    if (category.slots[i].runes[j].key == edited[9])
                                    {
                                        t2rune3[j].Image = new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon);
                                    }
                                    else
                                    {
                                        t2rune3[j].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.slots[i].runes[j].icon));
                                    }

                                    if (category.key != "Domination")
                                    {
                                        t2rune3[t2rune3.Count() - 1].Hide();
                                    }
                                    else
                                    {
                                        t2rune3[t2rune3.Count() - 1].Show();
                                    }

                                    PictBoxRunesNames.Add(t2rune3[j], category.slots[i].runes[j].key);
                                }
                                break;
                        }
                    }
                }
            }

            int counter = 0;
            foreach (RunesData.Category category in RunesData.root)
            {
                tree1[counter].Image = new Bitmap("./selfdata/loldata/img/" + category.icon);
                tree2[counter].Image = new Bitmap("./selfdata/loldata/img/" + category.icon);
                if (category.key != edited[1])
                {
                    tree1[counter].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.icon));
                }


                if (category.key != edited[6])
                {
                    tree2[counter].Image = Grayscale(new Bitmap("./selfdata/loldata/img/" + category.icon));
                }
                PictBoxTrees1Names.Add(tree1[counter], category.key);
                PictBoxTrees2Names.Add(tree2[counter], category.key);
                counter++;
            }

            

            MASTERLIST.Add(tree1);
            MASTERLIST.Add(t1rune1);
            MASTERLIST.Add(t1rune2);
            MASTERLIST.Add(t1rune3);
            MASTERLIST.Add(t1rune4);
            MASTERLIST.Add(tree2);
            MASTERLIST.Add(t2rune1);
            MASTERLIST.Add(t2rune2);
            MASTERLIST.Add(t2rune3);
            MASTERLIST.Add(statmod1);
            MASTERLIST.Add(statmod2);
            MASTERLIST.Add(statmod3);

        }

        //yup
        private void RunePageForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        
        //yup
        private void RunePageForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        //yup
        private void RunePageForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //yup
        private void exitButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(string.Join("", edited) + "\n" + string.Join("", file));
            exitButton.ForeColor = Color.Goldenrod;
            if (string.Join("", edited) != string.Join("", File.ReadAllText("./selfdata/runepages/" + MenuForm.currentUser + "/" + SRForm.currentRunepage + ".runespage")))
            {
                DialogResult exitResult = MessageBox.Show("Do you want to save any changes made?", "Runes Were Changed?", MessageBoxButtons.YesNoCancel);
                if (exitResult == DialogResult.Yes)
                {
                    try
                    {
                        File.WriteAllLines("./selfdata/runepages/" + MenuForm.currentUser + "/" + SRForm.currentRunepage + ".runespage", edited);
                        File.Move("./selfdata/runepages/" + MenuForm.currentUser + "/" + SRForm.currentRunepage + ".runespage", "./selfdata/runepages/" + MenuForm.currentUser + "/" + edited[0] + ".runespage");

                        SRForm.srform.rphelper();
                        this.Close();
                    }
                    catch (System.IO.IOException error)
                    {
                        Console.WriteLine(error.Message.ToUpper());
                        MessageBox.Show("You cannot use that name. It is already being used in your runepages!", "! Runepage Name Error !", MessageBoxButtons.OK);
                    }
                }
                else if (exitResult == DialogResult.No)
                {
                    this.Close();
                }
                
            }
            else
            {
                this.Close();
            }

            
        }

        //yup
        private void exitButton_MouseDown(object sender, MouseEventArgs e)
        {
            exitButton.ForeColor = Color.Blue;
        }

        //onclick event for every single rune (currently under development probably not now though)
        private void runeorstat_Click(object sender, EventArgs e)
        {
            var obj = sender as PictureBox;
            if (obj.Name.Contains("rune"))
            {
                foreach (RunesData.Category category in RunesData.root)
                {
                    if (category.key == file[1] || category.key == file[6])
                    {
                        foreach (RunesData.Slot slot in category.slots)
                        {
                            foreach (RunesData.Rune rune in slot.runes)
                            {
                                if (rune.key == PictBoxRunesNames[obj])
                                {
                                    Console.WriteLine("\n" + rune.key + " (rune.key) = " + PictBoxRunesNames[obj] + " (PictBoxRunesNames[obj])");

                                    for (int i = 0; i < MASTERLIST.Count(); i++)
                                    {
                                        foreach (PictureBox pb in MASTERLIST[i])
                                        {
                                            if (pb.Equals(obj) && edited[i+1] != "blank")
                                            {
                                                pb.ImageLocation = "./selfdata/loldata/img/" + rune.icon;
                                                Console.WriteLine("\n\nSet image {" + pb.Name + "}'s ImageLocation to: " + pb.ImageLocation);

                                                edited[i + 1] = rune.key;
                                                Console.WriteLine("\n" + string.Join("", edited));

                                                Console.WriteLine("\n\nWROTE {" + rune.key + "} to file line #" + (i+2) + " (zero-based # is " + (i+1) + ")");
                                            }
                                            else if (!pb.Equals(obj) && MASTERLIST[i].Contains(obj) && edited[i+1] != "blank")
                                            {
                                                pb.Image = Grayscale(new Bitmap(pb.Image));
                                                Console.WriteLine("\n\nobj {" + obj.Name + "} did not match {" + pb.Name + "}.\nImageLocation of obj: " + obj.ImageLocation + "\nGrayscaled.");

                                            }
                                            else if (pb.Equals(obj) && edited[i+1] == "blank")
                                            {
                                                pb.ImageLocation = "./selfdata/loldata/img/" + rune.icon;
                                                Console.WriteLine("\n\nSet image {" + pb.Name + "}'s ImageLocation to: " + pb.ImageLocation);

                                                edited[i + 1] = rune.key;
                                                Console.WriteLine("\n" + string.Join("", edited));

                                                Console.WriteLine("\n\nWROTE {" + rune.key + "} to file line #" + (i + 2) + " (zero-based # is " + (i + 1) + ")");

                                                if (!edited[i+2].Contains("StatMods"))
                                                {
                                                    edited[i + 2] = "blank";
                                                }
                                                else if (edited[i + 2].Contains("StatMods"))
                                                {
                                                    edited[i - 1] = "blank";
                                                }
                                            }


                                        }
                                    }
                            }
                            }
                        }
                    }
                }
            }
            else if (obj.Name.Contains("tree"))
            {
                foreach (RunesData.Category category in RunesData.root)
                {
                    try
                    {
                        if (category.key == PictBoxTrees1Names[obj])
                        {
                            for (int i = 0; i < MASTERLIST.Count(); i++)
                            {
                                foreach (PictureBox pb in MASTERLIST[i])
                                {
                                    if (PictBoxTrees1Names[obj] == edited[6])
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (pb.Equals(obj))
                                        {
                                            Console.WriteLine("SET " + obj.Name + "'s image to " + category.key);
                                            obj.ImageLocation = "./selfdata/loldata/img/" + category.icon;

                                            edited[i + 1] = category.key;
                                            Console.WriteLine("\n" + string.Join("", edited));

                                            Console.WriteLine("\n\nWROTE {" + category.key + "} to file line #" + (i + 2) + " (zero-based # is " + (i + 1) + ")");
                                        }
                                        else if (!pb.Equals(obj) && MASTERLIST[i].Contains(obj))
                                        {
                                            pb.Image = Grayscale(new Bitmap(pb.Image));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (System.Collections.Generic.KeyNotFoundException error)
                    {
                        if (category.key == PictBoxTrees2Names[obj])
                        {
                            for (int i = 0; i < MASTERLIST.Count(); i++)
                            {
                                foreach (PictureBox pb in MASTERLIST[i])
                                {
                                    if (PictBoxTrees2Names[obj] == edited[1])
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (pb.Equals(obj))
                                        {
                                            Console.WriteLine("SET " + obj.Name + "'s image to " + category.key);
                                            pb.ImageLocation = "./selfdata/loldata/img/" + category.icon;

                                            edited[i + 1] = category.key;
                                            Console.WriteLine("\n" + string.Join("", edited));

                                            Console.WriteLine("\n\nWROTE {" + category.key + "} to file line #" + (i + 2) + " (zero-based # is " + (i + 1) + ")");
                                        }
                                        else if (!pb.Equals(obj) && MASTERLIST[i].Contains(obj))
                                        {
                                            pb.Image = Grayscale(new Bitmap(pb.Image));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ReloadRunepage();
            }
            else if (obj.Name.Contains("statmod"))
            {
                if (obj.Name.Contains("statmod1"))
                {
                    foreach (PictureBox pb in statmod1)
                    {
                        if (pb.Equals(obj))
                        {
                            pb.ImageLocation = statmod1images[pb];
                            pb.BackColor = Color.FromArgb(50, Color.Black);
                            previous1 = pb;
                            Console.WriteLine("\nSet " + pb.Name + "'s image");

                            if (obj.Name.Contains("image3"))
                            {
                                edited[10] = "StatModsAdaptiveForce";
                            }
                            else if (obj.Name.Contains("image2"))
                            {
                                edited[10] = "StatModsAttackSpeed";
                            }
                            else if (obj.Name.Contains("image1"))
                            {
                                edited[10] = "StatModsCDRScaling";
                            }
                        }
                        else
                        {
                            pb.Image = Grayscale(new Bitmap(pb.Image));
                            pb.BackColor = Color.FromArgb(50, Color.White);
                        }
                    }
                }
                else if (obj.Name.Contains("statmod2"))
                {
                    foreach (PictureBox pb in statmod2)
                    {
                        if (pb.Equals(obj))
                        {
                            pb.ImageLocation = statmod2images[pb];
                            pb.BackColor = Color.FromArgb(50, Color.Black);
                            previous2 = pb;
                            Console.WriteLine("\nSet " + pb.Name + "'s image");

                            if (obj.Name.Contains("image3"))
                            {
                                edited[11] = "StatModsAdaptiveForce";
                            }
                            else if (obj.Name.Contains("image2"))
                            {
                                edited[11] = "StatModsArmor";
                            }
                            else if (obj.Name.Contains("image1"))
                            {
                                edited[11] = "StatModsMagicRes";
                            }
                        }
                        else
                        {
                            pb.Image = Grayscale(new Bitmap(pb.Image));
                            pb.BackColor = Color.FromArgb(50, Color.White);
                        }
                    }
                }
                else if (obj.Name.Contains("statmod3"))
                {
                    foreach (PictureBox pb in statmod3)
                    {
                        if (pb.Equals(obj))
                        {
                            pb.ImageLocation = statmod3images[pb];
                            pb.BackColor = Color.FromArgb(50, Color.Black);
                            previous3 = pb;
                            Console.WriteLine("\nSet " + pb.Name + "'s image");

                            if (obj.Name.Contains("image3"))
                            {
                                edited[12] = "StatModsHealthScaling";
                            }
                            else if (obj.Name.Contains("image2"))
                            {
                                edited[12] = "StatModsArmor";
                            }
                            else if (obj.Name.Contains("image1"))
                            {
                                edited[12] = "StatModsMagicRes";
                            }
                        }
                        else
                        {
                            pb.Image = Grayscale(new Bitmap(pb.Image));
                            pb.BackColor = Color.FromArgb(50, Color.White);
                        }
                    }
                }
                ReloadRunepage();
            }

            ReloadRunepage();
        }

        //changes image to grayscale. used in runes or whatever
        public Bitmap Grayscale(Bitmap image)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        private void PageTitle_TextChange(object sender, EventArgs e)
        {
            TextBox obj = sender as TextBox;
            edited[0] = obj.Text;
        }

        private void ImageBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox obj = sender as PictureBox;
            if (obj.Equals(previous1) || obj.Equals(previous2) || obj.Equals(previous3))
            {
                obj.BackColor = Color.FromArgb(50, Color.Black);
            }
            else
            {
                obj.BackColor = Color.FromArgb(50, Color.White);
            }
        }
        
        private void ImageBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox obj = sender as PictureBox;
            obj.BackColor = Color.White;
        }

        private void trashPageButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this runepage?", "Delete Runepage Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string f in Directory.GetFiles("./selfdata/runepages/" + MenuForm.currentUser + "/"))
                {
                    if (f.Contains(file[0]))
                    {
                        File.Delete(f);
                    }
                    SRForm.srform.rphelper();
                    this.Close();
                }
            }
        }
    }
}
