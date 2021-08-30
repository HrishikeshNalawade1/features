using System;
using System.Runtime.Serialization.Json;
using System.IO;

namespace serialize_1
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string[] skills { get; set; }
    }
    class JSONSerialization
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                EmployeeId = 121,
                EmployeeName = "Hrishi",
                skills = new string[] { "c#", "sql", "Linq" }
            };
            StreamWriter newStream = File.CreateText(@"C:\test\result.Json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Employee));
            using (FileStream file=new FileStream("resulst.Json",FileMode.OpenOrCreate,FileAccess.Write))
            {
                serializer.WriteObject(file, employee);
            }
            Console.WriteLine("deserializing the data .."); ;
            using (FileStream stream = new FileStream("resulst.Json", FileMode.OpenOrCreate, FileAccess.Read))
            {
                Employee emp = (Employee)serializer.ReadObject(stream);
                Console.WriteLine("{0}{1}",emp.EmployeeId,emp.EmployeeName);
                foreach(string skill in emp.skills)
                {
                    Console.WriteLine(skill);
                }
            }
        }
    }
}
