using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class OrderItem
    {
        string id, user_id, items_id;
        
        public OrderItem(string _id, string _user, string _items)
        {
            id = _id;
            user_id = _user;
            items_id = _items;
        }

        public string getID()
        {
            return id;
        }
        public string getUserID()
        {
            return user_id;
        }
        public string getItemsID()
        {
            return items_id;
        }
    }
}
