using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin;
using Product;
using ProxyPluginDemo.Plug;

namespace StartUp
{
    class Program
    {
        static PluginService<TestService> product = new PluginService<TestService>();

        static PluginInterfaceService<Test> Test = new PluginInterfaceService<Test>();
        
        static void Main(string[] args)
        {
            try
            {
                var file = AppDomain.CurrentDomain.BaseDirectory;
                var dlls = Directory.GetFiles(file, "*pl*.dll");
          
                foreach (var dll in dlls)
                {
                    try
                    {
                        System.Reflection.Assembly.LoadFile(dll);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }


                var aa = Test.Instance.T();

                product.Instance.HellowWord();
            
                product.Instance.DoSom();

                product.Instance.HellowWord();
            
                product.Instance.DoSom();

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


    public interface Test
    {
        int T();
    }
}
