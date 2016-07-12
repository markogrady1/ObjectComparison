using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectComparison;

namespace Tests
{
    [TestFixture]
    public class ObjectComparisonTest
    {
       [Test]
        public void should_return_comparison()
        {
            var person = new Person();
           person.Age = 33;
           person.Gender = "Male";
           person.Name = "Jack Black";
 
           var person2 = new Person();
           person2.Age = 43;
           person2.Gender = "Male";
           person2.Name = "Jack Blue";

           var compare = new Compare();
           var differences = compare.GetChanges(person, person2);

           Assert.That(differences.Count, Is.EqualTo(2));
           Assert.That(differences[0], Is.EqualTo("Name changed from Jack Black to Jack Blue"));
           Assert.That(differences[1], Is.EqualTo("Age changed from 33 to 43"));

        }
    }
}
