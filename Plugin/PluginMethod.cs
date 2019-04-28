using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Product;
using ProxyPluginDemo.Plug.Attrubute;

namespace Plugin
{
    /// <summary>
    /// 插件话
    /// </summary>
    [PluginClass(typeof(TestService))]
    public class PluginMethod
    {
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [PluginMethod(nameof(TestService.Calc))]
        public virtual int PlugCalc(int [] param)
        {
            Console.WriteLine("插件方法");

            var retVal = 0;
            for (int i = 0; i < param.Length; i++)
            {
                if (i % 2 == 0)
                {
                    retVal += param[i];
                }
                else
                {
                    retVal -= param[i];
                }
            }

            return retVal;
        } 
    }
}
