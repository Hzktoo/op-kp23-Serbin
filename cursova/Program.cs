using System;
using System.Drawing;
using System.Windows.Forms;

namespace CursovaForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CryptoForm mainForm = new CryptoForm();
            mainForm.Text = "Cryptowallet";
            mainForm.BackColor = Color.LightSlateGray;

            string logoImagePath = @"C:\Users\User\Downloads\free-icon-crypto-9478680.png";

            PictureBox logoPictureBox = new PictureBox();
            logoPictureBox.Image = Image.FromFile(logoImagePath);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.Location = new System.Drawing.Point(700, 150);
            logoPictureBox.Size = new Size(100, 100);

            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Welcome to KPICryptoWallet!";
            welcomeLabel.Font = new Font("Arial", 13, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new System.Drawing.Point(615, 320);
            welcomeLabel.AutoSize = true;

            SettedButton registerButton = new SettedButton();
            registerButton.Text = "Register";
            registerButton.FlatAppearance.BorderColor = registerButton.BackColor;
            registerButton.Location = new System.Drawing.Point(590, 370);
            registerButton.Click += mainForm.RegisterButton_Click;
            

            SettedButton loginButton = new SettedButton();
            loginButton.Text = "Login";
            loginButton.FlatAppearance.BorderColor = loginButton.BackColor;
            loginButton.Location = new System.Drawing.Point(840, 370);
            loginButton.Click += mainForm.LoginButton_Click;
            
            mainForm.Controls.Add(logoPictureBox);
            mainForm.Controls.Add(welcomeLabel);
            mainForm.Controls.Add(registerButton);
            mainForm.Controls.Add(loginButton);

            mainForm.ShowDialog();
        }
    }
}