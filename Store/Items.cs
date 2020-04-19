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
            this._name = name;
            this._price = price;
            this._image = image;
        }

        public Items(string id, string name, string price, string image)
        {
            this._name = name;
            this._price = price;
            this._image = image;
            this._id = id;
        }

        public Items(string id, string name, string price, string image, string q)
        {
            this._id = id;
            this._quantity = q;
            this._name = name;
            this._price = price;
            this._image = image;
        }


        public string getName()
        {
            return this._name;
        }

        public string getPrice()
        {
            return this._price;
        }
        public string getImage()
        {
            return this._image;
        }
        public string getQuantity()
        {
            return this._quantity;
        }

        public string getID()
        {
            return _id;
        }
    }
}
