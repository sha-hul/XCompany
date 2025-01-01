using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCompany.CompanyArea;

namespace XCompany
{
    internal class XCompanyApplication
    {
        
        public static void CallMain(string[] args)
        {
            if (args.Length != 2)
            {
                throw new Exception("Invalid number of arguments.");
            }
            List<string> commandLineArgs = new List<string>(args);
            string inputFile = commandLineArgs[0].Split('=')[1];
            string outputFile = commandLineArgs[1].Split('=')[1];
            Run(inputFile, outputFile);
        }

        public static void Run(string inputFile, string outputFile)
        {
            // Initialize Company
            Company company = Company.Create("Zipzo", new Employee("Shahul", Gender.MALE,""));
            
            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        List<string> tokens = new List<string>(line.Split(' '));

                        // Execute Services
                        switch (tokens[0])
                        {
                            case "REGISTER_EMPLOYEE":
                                {
                                    writer.WriteLine("REGISTER_EMPLOYEE :>");
                                    string employeeName = tokens[1];
                                    string gender = tokens[2];
                                    company.RegisterEmployee(employeeName, Enum.Parse<Gender>(gender));
                                    writer.WriteLine("EMPLOYEE_REGISTRATION_SUCCEEDED");
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "ASSIGN_MANAGER":
                                {
                                    writer.WriteLine("ASSIGN_MANAGER :>");
                                    string employeeName = tokens[1];
                                    string managerName = tokens[2];
                                    company.AssignManager(employeeName, managerName);
                                    writer.WriteLine("MANAGER_ASSIGNMENT_SUCCEEDED");
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "GET_EMPLOYEE":
                                {
                                    writer.WriteLine("GET_EMPLOYEE :>");
                                    string employeeName = tokens[1];
                                    Employee e = company.GetEmployee(employeeName);
                                    if (e == null)
                                    {
                                        writer.WriteLine("EMPLOYEE_NOT_FOUND");
                                    }
                                    else
                                    {
                                        writer.WriteLine(e.ToString());
                                    }
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "GET_DIRECT_REPORTS":
                                {
                                    writer.WriteLine("GET_DIRECT_REPORTS :>");
                                    string managerName = tokens[1];
                                    List<Employee> eList = company.GetDirectReports(managerName);
                                    writer.WriteLine(string.Join(", ", eList));
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "GET_TEAMMATES":
                                {
                                    writer.WriteLine("GET_TEAMMATES :>");
                                    string employeeName = tokens[1];
                                    List<Employee> eList = company.GetTeamMates(employeeName);
                                    writer.WriteLine(string.Join(", ", eList));
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "DELETE_EMPLOYEE":
                                {
                                    writer.WriteLine("DELETE_EMPLOYEE :>");
                                    string employeeName = tokens[1];
                                    company.DeleteEmployee(employeeName);
                                    writer.WriteLine("EMPLOYEE_DELETION_SUCCEEDED");
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            case "EMPLOYEE_HIERARCHY":
                                {
                                    writer.WriteLine("EMPLOYEE_HIERARCHY :>");
                                    string managerName = tokens[1];
                                    //List<List<Employee>> eLists = company.GetEmployeeHierarchy(managerName);
                                    //foreach (List<Employee> eList in eLists)
                                    //{
                                    //    foreach (Employee e in eList)
                                    //    {
                                    //        writer.Write(e.ToString() + "\t");
                                    //    }
                                    //    writer.WriteLine();
                                    //}
                                    writer.WriteLine();
                                    writer.Flush();
                                }
                                break;

                            default:
                                throw new Exception("Invalid Command");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
