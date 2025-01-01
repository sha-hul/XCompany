using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XCompany.CompanyArea
{
    public class Company
    {
        private string companyName;
        private Employee founder;
        private Dictionary<string, Employee> employeeBook;

        private Company(string companyName, Employee founder)
        {
            this.companyName = companyName;
            this.founder = founder;
            employeeBook = new Dictionary<string, Employee>();
            employeeBook.Add(founder.GetName(), founder);
        }

        public static Company Create(string companyName, Employee founder)
        {
            return new Company(companyName, founder);
        }

        public string GetCompanyName()
        {
            return companyName;
        }

        // TODO: CRIO_TASK_MODULE_XCOMPANY
        // Please define all the methods required here as mentioned in the XCompany BuildOut Milestone for each functionality before implementing the logic.
        // This will ensure that the project can be compiled successfully.
        public void RegisterEmployee(string employee, Gender gender)
        {
            Employee newEmp = new Employee(employee, gender, "");
            employeeBook.Add(newEmp.GetName(), newEmp);
        }

        public void AssignManager(string employeeName, string managerName)
        {
            foreach (var item in employeeBook)
            {
                if (item.Key == employeeName)
                {
                    employeeBook[item.Key] = new Employee(item.Value.GetName(), item.Value.GetGender(), managerName);
                    break;
                }
            }
        }
        public Employee GetEmployee(string emp)
        {
            if (!String.IsNullOrEmpty(emp))
                return employeeBook.GetValueOrDefault(emp);
            else
                return null;
        }

        public List<Employee> GetDirectReports(string manager)
        {
            List<Employee> emp = new List<Employee>();
            foreach (var item in employeeBook)
            {
                if (item.Value.GetManager() == manager)
                {
                    emp.Add(item.Value);
                }
            }
            return emp;
        }

        public List<Employee> GetTeamMates(string employee)
        {
            List<Employee> emp = new List<Employee>();
            //To find the manager
            string manager = string.Empty;
            foreach (var item in employeeBook)
            {
                if (item.Value.GetName() == employee)
                {
                    manager = item.Value.GetManager();
                }
            }
            //Add the team including manager
            foreach (var item in employeeBook)
            {
                if (item.Value.GetManager() == manager)
                {
                    emp.Add(item.Value);
                    continue;
                }
                if (item.Key == manager)
                {
                    emp.Add(item.Value);
                }
            }
            return emp;
        }
        public void DeleteEmployee(string empName) 
        {
            bool isManager = false;
            string manager = string.Empty;
            //check the employee is Manager or not
            foreach (var item in employeeBook)
            {
                if (item.Value.GetManager() == empName)
                {
                    isManager = true;
                }
                if (item.Value.GetName() == empName)
                {
                    manager = item.Value.GetManager();
                }
            }
            //Assign the Manager's Manager to the employee
            if (isManager)
            {
                foreach (var item in employeeBook)
                {
                    if (item.Value.GetManager() == empName)
                    {
                        employeeBook[item.Key] = new Employee(item.Value.GetName(),
                            item.Value.GetGender(), manager);
                    }
                }
            }
            employeeBook.Remove(empName);
        }

        public List<List<Employee>> GetEmployeeHierarchy(string empName)
        {
            var hierarchy = new List<List<Employee>>();
            var currentLevel = new List<Employee> { employeeBook[empName] };

            while (currentLevel.Count > 0)
            {
                hierarchy.Add(new List<Employee>(currentLevel)); // Add the current level to the hierarchy.

                var nextLevel = new List<Employee>();
                foreach (var employee in currentLevel)
                {
                    nextLevel.AddRange(GetDirectReports(employee.GetName()));
                }

                currentLevel = nextLevel; // Move to the next level of direct reports.
            }

            return hierarchy;
        }


    }
}
