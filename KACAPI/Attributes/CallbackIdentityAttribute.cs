using System;
using System.Collections.Generic;
using System.Text;

namespace KACAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
    class CallbackIdentityAttribute : Attribute
    {
        public int Identity { get; set; }

        public CallbackIdentityAttribute(int callbackNum)
        {
            Identity = callbackNum;
        }
    }

}
