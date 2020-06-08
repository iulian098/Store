using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class UserData
    {
        public int ID;
        public string username;
        public string email;
        public string address;

        public UserData(int _id, string _username, string _email, string _address)
        {
            this.ID = _id;
            this.username = _username;
            this.email = _email;
            this.address = _address;
        }
    }
}
