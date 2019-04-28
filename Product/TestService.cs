using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class TestService
    {
        public virtual void HellowWord()
        {
            Console.WriteLine("产品 hello word");
        }


        public virtual int Calc(int [] param)
        {
            return param.Sum();
        }

        public virtual void DoSom()
        {
            var toCalc = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                toCalc.Add(i + 1);
            }

            Console.WriteLine("计算：");

            Console.WriteLine("结果:" + Calc(toCalc.ToArray()));
        }
    }
}
