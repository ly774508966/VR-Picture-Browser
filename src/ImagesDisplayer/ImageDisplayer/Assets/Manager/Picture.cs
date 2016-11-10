﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class Picture
    {
        private string path;
        private string name;
        
        public Picture(string path)
        {
            this.path = path;
        }

        public string getName()
        {
            return name;
        }

        public string getPath()
        {
            return path;
        }

        override
        public bool Equals(Object obj)
        {
            if (obj is Picture)
            {
                Picture aPicture = (Picture)obj;
                return this.path.Equals(aPicture.getPath());
            } else
            {
                return false;
            }
        }
    }
}