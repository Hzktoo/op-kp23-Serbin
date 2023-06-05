using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class PremiumUser : User
    {
        private static bool _isPremium = false;

        public PremiumUser(string username, string email, string password)
            : base(username, email, password)
        {
        }

        public static bool IsPremiumUser()
        {
            return _isPremium;
        }

        public static void SetPremiumUser()
        {
            _isPremium = true;
        }
    }
}
