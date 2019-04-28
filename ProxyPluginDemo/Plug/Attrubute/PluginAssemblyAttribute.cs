using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPluginDemo.Plug.Attrubute
{
    /// <summary>
    /// 是否包含插件程序集
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class PluginAssemblyAttribute :Attribute
    {
    }
}
