using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Building_Organization
{
  public  class PersonsData
    {
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public PersonsData(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public PersonsData()
        {

        }
    }
}
