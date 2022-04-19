using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;
using System.Drawing.Design;
using System.IO;

namespace LOLTTIPN
{
    public partial class MenuForm : Form
    {
        SRForm SRForm = new SRForm();

        private bool mouseDown; //mousedown variable used in movable window 3-set
        private Point lastLocation; //lastlocation variable used in movable window 3-set
        private bool rememberMe = false; //rememberme variable used for the remember account button in the MenuForm

        public static string currentUser; //all caps string used across all forms to get the username of the current user (used in user-specific files, etc.)

        //standard windows stuff vvvvv
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //soon to be an included feature but currently this statement does nothing
            if (rememberMe)
            {
                rememberChkBox.Checked = true;
            }
            else
            {
                rememberChkBox.Checked = false;
            }
        }

        //used on various controls to paint a "Goldenrod" border around itself
        private void PaintGoldenrodBorderLABEL(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Goldenrod), new Rectangle(0, 0, ((Label)sender).Width - 1, ((Label)sender).Height - 1));
        }

        //part 1 of like, 3 for a movable window (since form has no form style)
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        //part 2 of like, 3 for a movable window (since form has no form style)
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        //part 3 of like, 3 for a movable window (since form has no forms style)
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //keydown event for the login button (specifically allowing the enter key to be used)
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginButton_Clicked();
            }
        }

        //used to exit the program when the X button is clicked
        private void exitButton_Click(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Goldenrod;
            DialogResult exitResult = MessageBox.Show("Are you sure you want to exit LOLTTIPN?", "Exit Confirm", MessageBoxButtons.YesNo);
            if (exitResult == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        //login button clicked massive function currently just opens a new form and reports back user's data in the console
        private void loginButton_Clicked(object sender = null, EventArgs e = null)
        {
            //for each account details file in the folder, check if password and username match in all caps

            string[] files = Directory.GetFiles("./selfdata/accounts");
            bool matched = false;
            foreach(string file in files)
            {
                if(File.ReadLines(file).ElementAt<string>(0) == userTextBox.Text.ToUpper() && File.ReadLines(file).ElementAt<string>(1) == passTextBox.Text)
                {
                    matched = true;

                    currentUser = File.ReadLines(file).ElementAt<string>(0);

                    Console.WriteLine("Filepath: " + file);
                    Console.WriteLine("Computer Read: " + File.ReadLines(file).ElementAt<string>(0) + " " + File.ReadLines(file).ElementAt<string>(1));
                    Console.WriteLine("User's Input: " + userTextBox.Text.ToUpper() + " " + passTextBox.Text);
                    break;
                }
                else if(File.ReadLines(file).ElementAt<string>(0) != userTextBox.Text.ToUpper() || File.ReadLines(file).ElementAt<string>(1) != passTextBox.Text)
                {
                    matched = false;

                    Console.WriteLine("Filepath: " + file);
                    Console.WriteLine("Computer Read: " + File.ReadLines(file).ElementAt<string>(0) + " " + File.ReadLines(file).ElementAt<string>(1));
                    Console.WriteLine("User's Input: " + userTextBox.Text.ToUpper() + " " + passTextBox.Text);
                }
                
            }

            if (matched)
            {
                //allow in and load that user's data
                LoadPage();
            }
            else if (!matched)
            {
                //error
                DialogResult wrongLogin = MessageBox.Show("ERROR - Wrong login information. Please enter in the correct information. Remember, the password is the only field that is case sensitive!", "ERROR", MessageBoxButtons.OK);
            }
        }

        //maximizes form
        private void maxiButton_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
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

        //minimizes form
        private void miniButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            miniButton.ForeColor = Color.Goldenrod;
        }

        //maximum button mousedown color change
        private void maxiButton_MouseDown(object sender, MouseEventArgs e)
        {
            maxiButton.ForeColor = Color.White;
        }

        //exit button mousedown color change
        private void exitButton_MouseDown(object sender, MouseEventArgs e)
        {
            exitButton.ForeColor = Color.White;
        }

        //minimize button mousedown color change
        private void miniButton_MouseDown(object sender, MouseEventArgs e)
        {
            miniButton.ForeColor = Color.White;
        }

        //checkchanged event for the checkbox (remember, currently useless)
        private void rememberChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberChkBox.Checked && userTextBox.Text != "" && passTextBox.Text != "")
            {
                rememberMe = true;
            }
            else
            {
                rememberMe = false;
            }
        }

        //logout button click event to logout user back to MainForm
        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (rememberMe)
            {
                //do nothing
            }
            else
            {
                userTextBox.Text = "";
                passTextBox.Text = "";
                rememberChkBox.Checked = false;
            }
            LoadPage("menu");
        }

        //loads a specific "page" (e.x. "Champions", "Runepages", "Items"; there are buttons at the top of the summoner's rift form)
        public void LoadPage(string game = null, string page = "profile")
        {
            switch (game)
            {
                case "lol":
                    if (!(this.WindowState == FormWindowState.Maximized))
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                    }


                    break;
                case "menu":
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }

                    foreach (Control element in this.Controls)
                    {
                        switch (element.Name)
                        {
                            case "exitButton":
                                element.Show();
                                break;
                            case "maxiButton":
                                element.Show();
                                break;
                            case "miniButton":
                                element.Show();
                                break;
                            case "menuIconPicBox":
                                element.Show();
                                break;
                            case "titleMenuLabel":
                                element.Show();
                                break;
                            case "userLabel":
                                element.Show();
                                break;
                            case "passLabel":
                                element.Show();
                                break;
                            case "userTextBox":
                                element.Show();
                                break;
                            case "passTextBox":
                                element.Show();
                                break;
                            case "loginButton":
                                element.Show();
                                break;
                            case "logoutButton":
                                element.Show();
                                break;
                            case "rememberChkBox":
                                element.Show();
                                break;
                            default:
                                element.Hide();
                                break;
                        }
                    }
                    break;
                case "aram":
                    break;
                case "tft":
                    break;
                case "lor":
                    break;
                default:
                    foreach (Control element in this.Controls)
                    {
                        if (element.Name == "exitButton" || element.Name == "maxiButton" || element.Name == "miniButton" || element.Name == "logoutButton")
                        {
                            //do nothing
                        }
                        else if (element.Name == "SRiconPicBox" || element.Name == "ARAMiconPicBox" || element.Name == "TFTiconPicBox" || element.Name == "LORiconPicBox" || element.Name == "SRiconLabel" || element.Name == "ARAMiconLabel" || element.Name == "TFTiconLabel" || element.Name == "LORiconLabel")
                        {
                            element.Show();
                        }
                        else
                        {
                            element.Hide();
                        }
                    }
                    break;
            }
        }

        //onclick event for the summoner's rift icon (opens new form and starts up SRForm)
        private void SRiconPicBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            SRForm.Show();
        }

        //formclosed MenuForm event that is called on close
        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("\n\n\nMENUFORM HAS BEEN CLOSED\n\n\n");
        }
    }
}