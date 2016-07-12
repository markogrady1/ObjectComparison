using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparison
{
    public class Compare
    {
        public int length;

        public List<string> GetChanges(Person firstInstance, Person secondInstance)
        {
            length = 0;
            List<string> diffs = new List<string>();
            int name = firstInstance.Name.CompareTo(secondInstance.Name);
            int age = firstInstance.Age.CompareTo(secondInstance.Age);
            int gender = firstInstance.Gender.CompareTo(secondInstance.Gender);
            foreach (var prop in firstInstance.GetType().GetProperties())
            {
                if (prop.Name.Equals("Name") && name == -1)
                {
                    length++;
                    diffs.Add("Name changed from " + firstInstance.Name + " to " + secondInstance.Name);
                }
                if (prop.Name.Equals("Age") && age == -1)
                {
                    length++;
                    diffs.Add("Age changed from " + firstInstance.Age + " to " + secondInstance.Age);
                }
                if (prop.Name.Equals("Gender") && gender == -1)
                {
                    length++;
                    diffs.Add("Gender changed from " + firstInstance.Gender + " to " + secondInstance.Gender);
                }
            }
            return diffs;
        }
    }
}
