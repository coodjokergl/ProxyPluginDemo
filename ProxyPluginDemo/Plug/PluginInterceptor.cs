using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace ProxyPluginDemo.Plug
{
    /// <summary>
    /// 插件拦截器
    /// </summary>
    internal class PluginInterceptor:IInterceptor  
    {
        Guid curId = Guid.NewGuid();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("AOP id " + curId);

            if (!invocation.MethodInvocationTarget.IsAbstract)
            {
                //替换插件方式
                var plugInstance = PluginFactory.GetPluginMember(invocation.TargetType);
                if (plugInstance != null)
                {
                    if (plugInstance.Invoke(invocation.MethodInvocationTarget.Name, out object retVal,
                        invocation.Arguments))
                    {
                        invocation.ReturnValue = retVal;
                        return;
                    }
                }
            }   

            //执行原对象中的方法  
            invocation.Proceed(); 
        }
    }
}
