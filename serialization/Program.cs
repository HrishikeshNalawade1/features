using System;
using System.Xml.Serialization;
using System.IO;

namespace serialization
{
    namespace Serialize
    {
        [XmlRoot(ElementName = "Employee")]
        public class Employee
        {
            private string empID;
            private string empName;
            private int empAge;
            private string[] empskill;
            [XmlAttribute(AttributeName = "EmpID")]
            public string EmpID
            {
                get { return empID; }
                set { empID = value; }
            }
            [XmlElement(ElementName = "name")]
            public string Name
            {
                get { return empName; }
                set { empName = value; }
            }
            [XmlElement(ElementName = "Age")]
            public int Age
            {
                get { return empAge; }
                set { empAge = value; }
            }
            [XmlElement(ElementName = "Skill")]
            public string[] Skill
            {
                get { return empskill; }
                set { empskill = value; }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Employee SerializeEmp = new Employee();
                string[] empskills = { "c#", "SQL server 2000" };
                SerializeEmp.EmpID = "emp1";
                SerializeEmp.Name = "hrishi";
                SerializeEmp.Age = 23;
                SerializeEmp.Skill = empskills;

                StreamWriter newStream = File.CreateText(@"c:\test1\samplew.xml");
                XmlSerializer xmlSerialize = new XmlSerializer(typeof(Employee));

                  xmlSerialize.Serialize(newStream, SerializeEmp);
                newStream.Close();
                Employee deserializeEmp = new Employee();


                StreamReader readStream = File.OpenText(@"c:\test1\samplew.xml");
                xmlSerialize = new XmlSerializer(typeof(Employee));
                

                deserializeEmp = (Employee)xmlSerialize.Deserialize(readStream);
                readStream.Close();
                Console.WriteLine( "Deserialize object :"+deserializeEmp.Name);
                Console.WriteLine("deserialize object:"+ SerializeEmp.Name);

            }
        }
    }
}
