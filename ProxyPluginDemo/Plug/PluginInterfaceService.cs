using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace ProxyPluginDemo.Plug
{
    /// <summary>
    /// 插件服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PluginInterfaceService<T> where T :class
    {
        private T _instance;
        public T Instance => GetInstance();

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        protected virtual T GetInstance()
        {
            if (_instance == default(T))
            {
                lock (this)
                {
                    if (_instance == default(T))
                    {
                        //给person类生成代理   
                        ProxyGenerator generator = new ProxyGenerator();   
                        _instance = generator.CreateInterfaceProxyWithoutTarget<T>(new InterfaceInterceptor());
                    }
                }
            }

            return _instance;
        }
    }
}
