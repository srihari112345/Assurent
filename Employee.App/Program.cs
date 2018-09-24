using Employee.Api.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Employee.App
{
    class Program
    {
        //static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            Console.WriteLine("1) Fetch All/ {n} employees that are actively not engaged on an Project ");
            Console.WriteLine("2) Fetch All /{n} employees that are actively engaged on 1 project ");
            Console.WriteLine("3) Fetch All /{n} employees that are actively engaged in multiple projects");
            Console.Write("Enter the Option: ");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    employees = GetEmployeeEngagementAsync("https://localhost:44362/api/employee/zero/project").GetAwaiter().GetResult();
                    WrtieToFile(employees, "Zero");
                    break;

                case 2:
                    employees = GetEmployeeEngagementAsync("https://localhost:44362/api/employee/single/project").GetAwaiter().GetResult();
                    WrtieToFile(employees, "Single");
                    break;
                case 3:
                    employees = GetEmployeeEngagementAsync("https://localhost:44362/api/employee/multiple/projects").GetAwaiter().GetResult();
                    WrtieToFile(employees, "Multiple");
                    break;
            }
        }

        static async Task<List<EmployeeDTO>> GetEmployeeEngagementAsync(string url)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                 
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        employees = await response.Content.ReadAsAsync<List<EmployeeDTO>>();
                    }
                }
                return employees;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
                return null;
            }
        }

        static void WrtieToFile(List<EmployeeDTO> employeeList, string type)
        {
            try
            {
                Console.WriteLine("Writing to file..");
                var count = 1;
                var splitList = employeeList.Select((x, i) => new { Index = i, Value = x })
                                             .GroupBy(x => x.Index / 100)
                                             .Select(x => x.Select(v => v.Value).ToList())
                                             .ToList();
                splitList.ForEach(x =>
                {
                    using (TextWriter tw = new StreamWriter("D:\\Project\\AssurantAssignment\\Report\\" + type + "Project\\Report" + count + ".txt"))
                    {
                        foreach (var item in x)
                        {
                            tw.WriteLine(string.Format("EmployeeId: {0} - Name: {1} - BaseLocation: {2}", item.EmployeeId.ToString(), item.Name, item.BaseLocation));
                        }
                    }
                    count++;
                });
                Console.WriteLine("Reports Generated");
                Console.WriteLine("Press any key..");
                Console.ReadKey();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                Console.ReadKey();
            }
        }
    }
}
