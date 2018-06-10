using System;
using System.Collections.Generic;

namespace Catalog.Core
{
    public class DataService
    {
        public DataService()
        {
            var eagles = new Team { Name = "Eagles" };
            var bears = new Team { Name = "Bears" };

            Teams = new List<Team>
            {
                eagles,
                bears
            };

            People = new List<Person>
            {
                new Person { Name = "John" },
                new Person { Name = "Joe" },
                new Person { Name = "Ed", Team = eagles },
                new Person { Name = "Merphy", Team = bears },
                new Person { Name = "Met", Team = bears },
            };
          
        }

        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}
