using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public abstract class User
    {
        protected readonly string _username;
        protected readonly string _password;
        protected readonly string _email;

        public User(string username, string email, string password)
        {
            _username = username;
            _password = password;
            _email = email;
        }

        public string GetUsername() => _username;
        public string GetEmail() => _email;
    }
}
