using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace LINQ
{
    public interface IEnumerable
    {
        IEnumerator<int> GetEnumerator();
    }

   class Program
    {

        static void Main(string[] args)
        {
            #region
            /*Type type = typeof(Student);
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { });
            object student = constructorInfo.Invoke(new object[] { });
            var fields = type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
            foreach(FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == "temp")
                {
                    var value = fieldInfo.GetValue(student);
                    Console.WriteLine("Before{0}", value);
                    fieldInfo.SetValue(student, 15);
                    value = fieldInfo.GetValue(student);
                    Console.WriteLine("After{0}", value);
                }
                 
            }*/
            #endregion
            var r = new Random();
            var products = new List<Product>();
            for (var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = r.Next(10, 12)
                };
                products.Add(product);
            }
            var result = from item in products
                         where item.Energy < 200
                         select item;
            var result2 = products.Where(item => item.Energy < 200 || item.Energy > 400);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            var selectCollection = products.Select(product => product.Energy);
            foreach (var item in selectCollection)
                Console.WriteLine(item);
            var orderbyCollection = products.OrderBy(product => product.Energy)
                                            .ThenBy(product => product.Name);
            foreach (var item in orderbyCollection)
                Console.WriteLine(item);
            var groupbyCollection = products.GroupBy(product => product.Energy);
            foreach (var group in groupbyCollection)
            {
                Console.WriteLine($"Ключ:{group.Key}");
                foreach (var item in group) {
                    Console.WriteLine($"\t{item}");
                }

            }
            products.Reverse();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(products.All(item => item.Energy == 10));
            Console.WriteLine(products.Any(item => item.Energy == 10));
            var prod = new Product();
            Console.WriteLine(products.Contains(prod));
            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { };
            foreach(var item in array){
                Console.WriteLine(item);
            }
            var inion = array.Intersect(array2);
            foreach (var item in inion)
            {
                Console.WriteLine(item);
            }
            var except = array2.Except(array);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(array.Skip(1).Take(2).Aggregate((x,i)=>x*i));
            Console.WriteLine(array2.FirstOrDefault());



            Console.ReadLine();
        }
    }

    
    public class Student
    {
        private int temp = 7;
        public string Name { get; set; }


        [MySimple(Num=5)]
        public string Xuy { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MySimpleAttribute : Attribute
    {
        public int Num { get; set; }
    }
}
