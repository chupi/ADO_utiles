using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flavonoides
{
    class LinkException:Exception
    {
        string m;
        public LinkException(string message)
        {
            m = message;
        }
        public string mensaje
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }


    }
}
