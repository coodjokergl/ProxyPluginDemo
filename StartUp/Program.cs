using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Product;
using ProxyPluginDemo.Plug;

namespace StartUp
{
    class Program
    {
        static PluginService<TestService> product = new PluginService<TestService>();

        static void Main(string[] args)
        {
            try
            {
              
                var file = @"E:\售楼源码\Slxt2.0\src\00_根目录\bin";
                //file = AppDomain.CurrentDomain.BaseDirectory;
                var dlls = Directory.GetFiles(file, "*.dll");

                foreach (var dll in dlls)
                {
                    try
                    {
                        Assembly.LoadFrom(dll);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

               
                product.Instance.HellowWord();
            
                product.Instance.DoSom();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.ReadKey();
        }
    }
}
