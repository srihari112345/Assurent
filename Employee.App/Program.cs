using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Employee.App
{

    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string BaseLocation { get; set; }

        public Employee() { }
    }

    
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Option\n");
            Console.WriteLine("1) Fetch All/ {n} employees that are actively not engaged on an Project ");
            Console.WriteLine("2) Fetch All /{n} employees that are actively engaged on 1 project ");
            Console.WriteLine("3) Fetch All /{n} employees that are actively engaged in multiple projects");
            var option = Console.Read();

            switch(option)
            {
                case 1: 
                        SingleProjectAsync().GetAwaiter().GetResult();
                        break;
                case 2:
                    break;
                case 3:
                    break;
            }

           // RunAsync().GetAwaiter().GetResult() ;
        }

        static async Task SingleProjectAsync()
        {

            List<Employee> employees = new List<Employee>();
            try
            {
                Console.ReadKey();
                client.BaseAddress = new Uri("http://localhost:44362/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "https://localhost:44362/api/employee/single/project";

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    employees = await response.Content.ReadAsAsync<List<Employee>>();
                    Console.WriteLine(employees[0].Name);
                    Console.ReadKey();
                }

                var contentsToWriteToFile = JsonConvert.SerializeObject(employees);

                StreamWriter writer = new StreamWriter("D:\\Project\\AssurantAssignment\\Employee.txt", false);
                writer.Write(contentsToWriteToFile);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
        }
    }
}
