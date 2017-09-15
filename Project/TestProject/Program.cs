using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Picks up file from "{ProjectPath}/bin/debug/data.json"
            JsonMapper userInformation = JsonFlattener.LoadJson(Directory.GetCurrentDirectory() + @"\data.json");

            var result = JsonFlattener.Flatten(userInformation);

            string resultDirectory = Directory.GetCurrentDirectory();
            var resultPath = resultDirectory + @"\output.txt";
            JsonFlattener.WriteJson(resultPath, result);

            Console.WriteLine("______________Mapping Completed__________");
            Console.WriteLine("Data has been written to {Project Dir}/bin/debug/output.txt file");
           


        }
       
    }
}

