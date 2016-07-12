using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectComparison
{
    public class Compare
    {
        public int length;

        public List<string> GetChanges(Object firstInstance, Object secondInstance)
        {
            length = 0;
            var diffs = new List<string>();
            var tmp = new List<string>();
            Type t1 = firstInstance.GetType();
            Type t2 = secondInstance.GetType();

            if (!isSameObject(t1, t2))
            {
                return diffs;
            }

            firstInstance.GetType().GetProperties().ToList().ForEach(p => { tmp.Add(p.Name); });

            int count = 0;
            foreach (
                PropertyInfo pi in
                    t1.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                count++;
                object val = pi.GetValue(firstInstance);
                object tval = pi.GetValue(secondInstance);
                if (val != tval)
                {
                    string field = tmp[count - 1];
                    diffs.Add(field + " changed from " + val + " to " + tval);
                }
            }
            return diffs;
        }


        private bool isSameObject(Type obj1, Type obj2)
        {
            bool result = false;
            foreach (Object info in obj1.GetProperties())
            {
                foreach (Object info2 in obj2.GetProperties())
                {
                    if (info == info2)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
