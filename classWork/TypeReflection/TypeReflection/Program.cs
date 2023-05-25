using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;
using System.Reflection;

namespace TypeReflection
{
    
    internal class Program   
    {
        static void Main(string[] args)
        {
            var type = typeof(MyClass);
            //var type = Type.GetType("TypeReflection.MyClass");

            

           PrintTypeInfo(type);

            Console.WriteLine( );

            //type = typeof(string);
            //PrintTypeInfo(type);

            var obj = new MyClass(1);
            type = obj.GetType();
            obj.PublicProperty = 5;
            obj.PublicField = -2;
            var result = obj.MyMethod(3);
            Console.WriteLine(result);

            type=typeof(MyClass);
            var obj2 = type
                .GetConstructor(new Type[] { typeof(int) })
                .Invoke(new object[] {1});//вызывает метод

            type
                .GetProperty("PublicProperty")
                .SetValue(obj2, 5);

            type
                .GetField("PublicField")
                .SetValue(obj2,-2);

            type
                .GetField("privateField", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(obj2, 10);

            var val = type
                .GetField("privateField", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(obj2);
            Console.WriteLine(val);

            result=(int)type
                .GetMethod("MyMethod")
                .Invoke(obj2,new object[] {3});

            Console.WriteLine(result);

            Console.ReadKey();
        }

        static void PrintTypeInfo(Type type)
        {
            Console.WriteLine("===== Тип =====");
            Console.WriteLine(type.Name);

            Console.WriteLine("===== Поля ======");
            PrintNames(type
                .GetFields()
                .Select(f => f.Name));

            Console.WriteLine("===== Свойства ======");
            var propertyNames=type
                .GetProperties()
                .Select(p => p.Name);
            PrintNames(propertyNames);

            Console.WriteLine("===== Методы ======");
            PrintNames(type
                .GetMethods()
                .Select(m => m.Name));

            Console.WriteLine("===== Интерфейсы ======");
            PrintNames(type
                .GetInterfaces()
                .Select (i => i.Name));

            Console.WriteLine("===== Закрытые поля ======");
            PrintNames(type
                .GetFields(BindingFlags.NonPublic |  BindingFlags.Instance)
                .Select(f => f.Name));

            Console.WriteLine("===== Статические поля ======");
            PrintNames(type
                .GetFields(BindingFlags.Static)
                .Select (f => f.Name));

            Console.WriteLine("======  Конструкторы ======");
            PrintNames(type
               .GetConstructors()
               .Select(f => f.Name));

            Console.WriteLine("===== Атрибуты =====");
            PrintNames(type
                .GetCustomAttributes(true)
                .Select(f => f.GetType().Name));

            var descriptions = type.GetCustomAttributes<DescriptionAttribute>();
            if (descriptions.Count() > 0)
            {
                Console.WriteLine("===== Атрибуты Discription =====");
                PrintNames(descriptions.Select(x => x.Text));
            }

        }

        static void PrintNames(IEnumerable<string> names)
        {
            foreach (var name in names)
                Console.WriteLine($"->{name}");
        }
    }
}
