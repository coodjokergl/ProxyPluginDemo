using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPluginDemo.Plug.Attrubute
{
    [AttributeUsage(AttributeTargets.Class,Inherited = true)]
    public class PluginClassAttribute:Attribute
    {
        public Type FromType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public PluginClassAttribute(Type type)
        {
            FromType = type;
        }
    }
}
