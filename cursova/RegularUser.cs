using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class RegularUser : User
    {
        public RegularUser(string username, string email, string password)
            : base(username, email, password)
        {
        }
    }
}
