using System;
using System.Collections.Generic;
using System.Web;

namespace flavonoides
{
    public class ArraySet
    {
        private System.Collections.ArrayList al;
        public ArraySet()
        {
            al = new System.Collections.ArrayList();
        }
        public System.Collections.ArrayList Source
        {
            get
            {
                return al;
            }
            set
            {
                al = value;
            }
        }
        public void add(string svalor)
        {
            if (al.Contains(svalor) == false)
            {
                al.Add(svalor);
            }
        }
    }
}
