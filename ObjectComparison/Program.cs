using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Age = 55;
            p.Gender = "Male";
            p.Name = "Bob";

            Person p2 = new Person();
            p2.Age = 55;
            p2.Gender = "Male";
            p2.Name = "Billy";

            Compare cc = new Compare();
            List<string> differences = cc.GetChanges(p, p2);
            if (differences.Count > 0)
            {
                Console.Write(differences[0]);
            }
            Console.Write(cc.length);

           
            Console.ReadLine();
        }
    }
}
