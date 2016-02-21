using System;
using System.Collections.Generic;
using System.Text;

namespace KACAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    class InterfaceVersionAttribute : Attribute
    {
        public string Identifier { get; set; }

        public InterfaceVersionAttribute(string versionIdentifier)
        {
            Identifier = versionIdentifier;
        }
    }
}
