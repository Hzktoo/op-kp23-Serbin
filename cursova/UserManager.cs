using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public abstract class UserManager
    {
        protected string UsersFilePath = "D:\\users.txt";

        public abstract bool IsUserLoggedIn();
        public abstract void RegisterUser();
        public abstract void Login();
        public abstract string GetLoggedInUserName();
        public abstract void Logout();

        protected bool IsUserRegistered(string email)
        {
            if (File.Exists(UsersFilePath))
            {
                string[] lines = File.ReadAllLines(UsersFilePath);
                foreach (string line in lines)
                {
                    string[] userInfo = line.Split(',');

                    if (userInfo.Length >= 3 && userInfo[1] == email)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
