using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace ProxyPluginDemo.Plug
{
    public class InterfaceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = 100;
        }
    }
}
