using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Items
    {
        string _name, _price, _image, _quantity, _id;
        public Items(string name, string price, string image)
        {
            _name = name;
            _price = price;
            _image = image;
        }

        public Items(string name, string price, string image, string q, string id)
        {
            _id = id;
            _quantity = q;
            _name = name;
            _price = price;
            _image = image;
        }
        public string getName()
        {
            return _name;
        }

        public string getPrice()
        {
            return _price;
        }
        public string getImage()
        {
            return _image;
        }
        public string getQuantity()
        {
            return _quantity;
        }

        public string getID()
        {
            return _id;
        }
    }
}
