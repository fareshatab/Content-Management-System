using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
    public class DublicationEmailOrPhone : Exception
    {
        public DublicationEmailOrPhone() : base("This Account Is Alradey Exist !") { }
    }
}
