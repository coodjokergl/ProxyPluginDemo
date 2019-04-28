using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPluginDemo.Plug.Attrubute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PluginMethodAttribute:Attribute
    {
        public string MethodName { get; }

        public PluginMethodAttribute(string mathodName)
        {
            MethodName = mathodName;
        }
    }
}
