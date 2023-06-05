using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class AuthenticationManager : UserManager
    {
        private bool isLoggedIn = false;
        private string loggedInUserName = string.Empty;
        private User loggedInUser = null;

        public override bool IsUserLoggedIn()
        {
            return isLoggedIn;
        }

        public override void RegisterUser()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "User Registration");
            string email = Microsoft.VisualBasic.Interaction.InputBox("Enter your email:", "User Registration");
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "User Registration");

            if (IsUserRegistered(email))
            {
                MessageBox.Show("User with this email already exists.", "User Registration");
                return;
            }

            User currentUser = new RegularUser(name, email, password);
            string userData = $"{name},{email},{password}";
            File.AppendAllText(UsersFilePath, userData + Environment.NewLine);

            MessageBox.Show("Registration successful.", "User Registration");
        }

        public override void Login()
        {
            string email = Microsoft.VisualBasic.Interaction.InputBox("Enter your email:", "User Login");
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "User Login");

            if (!IsUserRegistered(email))
            {
                MessageBox.Show("User with this email does not exist.", "User Login");
                return;
            }

            string[] lines = File.ReadAllLines(UsersFilePath);
            foreach (string line in lines)
            {
                string[] userInfo = line.Split(',');

                if (userInfo.Length >= 3 && userInfo[1] == email && userInfo[2] == password)
                {
                    isLoggedIn = true;
                    loggedInUserName = userInfo[0];
                    loggedInUser = new RegularUser(loggedInUserName, email, password);
                    MessageBox.Show($"Welcome, {loggedInUserName}!", "User Login");
                    return;
                }
            }

            MessageBox.Show("Invalid email or password.", "User Login");
        }

        public override string GetLoggedInUserName()
        {
            return loggedInUserName;
        }

        public override void Logout()
        {
            isLoggedIn = false;
            loggedInUserName = string.Empty;
            loggedInUser = null;
        }
    }
}
