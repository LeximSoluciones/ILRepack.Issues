using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Repro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");
            var basePath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.FullName;
            Console.WriteLine($"Base Path: {basePath}");

            Console.WriteLine("Loading Assembly packed with ILRepack.MSBuild.Task V1");
            var file1 = Path.Combine(basePath, @"Using.ILRepack.V1\bin\Debug\net462\Using.ILRepack.V1.dll");
            var assembly1 = Assembly.Load(File.ReadAllBytes(file1));

            Console.WriteLine("Assembly Loaded. Instantiating Type");
            var t1 = assembly1.GetTypes().First(x => x.Name == "Dependent");

            Console.WriteLine("Creating object instance");
            var i1 = Activator.CreateInstance(t1);

            Console.WriteLine("Invoking Method");
            var result1 = i1.GetType().GetMethod("Run").Invoke(i1, null).ToString();
            Console.WriteLine($"Method Result: {result1}");

            //--------------------------------------------------------------------------------

            Console.WriteLine("Loading Assembly packed with ILRepack.MSBuild.Task V2");
            var file2 = Path.Combine(basePath, @"Using.ILRepack.V2\bin\Debug\net462\Using.ILRepack.V2.dll");
            var assembly2 = Assembly.Load(File.ReadAllBytes(file2));

            Console.WriteLine("Assembly Loaded. Instantiating Type");
            var t2 = assembly2.GetTypes().First(x => x.Name == "Dependent");

            Console.WriteLine("Creating object instance");
            var i2 = Activator.CreateInstance(t2);

            Console.WriteLine("Invoking Method");
            var result2 = i2.GetType().GetMethod("Run").Invoke(i2, null).ToString();
            Console.WriteLine($"Method Result: {result2}");

            //--------------------------------------------------------------------------------
            Console.WriteLine("Completed.");
            Console.ReadLine();
        }
    }
}
