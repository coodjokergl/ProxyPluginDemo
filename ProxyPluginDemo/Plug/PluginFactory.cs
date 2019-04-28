using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProxyPluginDemo.Plug.Attrubute;

namespace ProxyPluginDemo.Plug
{
    /// <summary>
    /// 插件工厂
    /// </summary>
    internal static class PluginFactory
    {
        static PluginFactory()
        {
            InitFactory();
        }

        /// <summary>
        /// 初始化工厂
        /// </summary>
        static void InitFactory()
        {
            lock (PluginMenmberTable.SyncRoot)
            {
                PluginMenmberTable.Clear();

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(q => q.GetCustomAttribute<PluginAssemblyAttribute>() != null))
                {
                    foreach (var plugType in assembly.GetExportedTypes().Where(q => q.IsClass &&
                                                                                  !q.IsAbstract
                                                                                  && q.GetCustomAttribute<PluginClassAttribute>() != null))
                    {
                        var plugAttr = plugType.GetCustomAttribute<PluginClassAttribute>();

                        var member = new PluginClassMember()
                        {
                            FromType = plugAttr.FromType,
                            TargetType = plugType,
                            PluginMethod = new Dictionary<string, MethodInfo>()
                        };

                        foreach (var method in plugType.GetMethods().Where(q=>q.IsPublic).Select(q=>new
                        {
                            Method = q,
                            PluginAttr = q.GetCustomAttribute<PluginMethodAttribute>()
                        }).Where(q=>q.PluginAttr != null))
                        {
                            //收集扩展方法
                            member.PluginMethod[method.PluginAttr.MethodName] = method.Method;
                        }

                        PluginMenmberTable.Add(member.FromType,member);
                    }
                }
            }
        }

        private static readonly Hashtable PluginMenmberTable = new Hashtable();
        

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PluginClassMember GetPluginMember(Type type)
        {
            return PluginMenmberTable[type] as PluginClassMember;
        }
    }

    /// <summary>
    /// 扩展方法成员
    /// </summary>
    internal class PluginClassMember
    {
        /// <summary>
        /// 来源类型
        /// </summary>
        internal Type FromType { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
        internal Type TargetType { get; set; }

        /// <summary>
        /// 插件方法
        /// </summary>
        internal Dictionary<string, MethodInfo> PluginMethod { get; set; }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="returnVal"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal bool Invoke(string method, out object returnVal, object[] parameters)
        {
            returnVal = null;
            if (PluginMethod != null && PluginMethod.TryGetValue(method, out MethodInfo methodInfo))
            {
                var obj = Activator.CreateInstance(TargetType);
                returnVal = methodInfo.Invoke(obj, parameters);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
