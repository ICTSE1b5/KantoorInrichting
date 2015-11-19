﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers.Product
{
    public class Product
    {
        public string name { get; private set; }
        public string brand { get; private set; }
        public string type { get; private set; }

        public int length { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        
        //public Supplier supplier { get; private set; }
        //public Category category { get; private set; }
        //public Image image { get; private set; }

        public string description { get; private set; }
        public int amount { get; private set; }

        public Product(string n, string b, string t, int l, int w, int h, string d, int a)
        {
            name = n;
            brand = b;
            type = t;

            length = l;
            width = w;
            height = h;

            description = d;
            amount = a;
        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        public Product() : this("", "", "", 0, 0, 0, "", 0) { }

    }
}
