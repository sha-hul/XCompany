using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCompany.CompanyArea
{


    public class Employee
    {
        private string name;
        private string manager;
        private Gender gender;

        public Employee(string name, Gender gender, string manager)
        {
            this.name = name;
            this.gender = gender;
            this.manager = manager;
        }

        public string GetName()
        {
            return name;
        }

        public Gender GetGender()
        {
            return gender;
        }

        public string GetManager()
        {
            return manager;
        }

        // TODO: CRIO_TASK_MODULE_XCOMPANY
        // Please define all the methods required here as mentioned in the XCompany BuildOut Milestone before implementing the logic.
        // This will ensure that the project can be compiled successfully.

        public override string ToString()
        {
            return $"Employee [name={name}, gender={gender}]";
        }
    }

}