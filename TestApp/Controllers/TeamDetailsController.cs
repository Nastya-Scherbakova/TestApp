using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Catalog.Core;

namespace TestApp.Controllers
{
    [Produces("application/json")]
    [Route("api/TeamDetails")]
    public class TeamDetailsController : Controller
    {
        public static List<Team> Teams { get; set; }
        public static List<Person> Persons { get; set; }
        static TeamDetailsController()
        {
            DataService data = new DataService();
            Teams = data.Teams.ToList();
            Persons = data.People.ToList();

        }
        // GET: api/TeamDetails
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> output = new List<string>();
            foreach (var Team in Teams)
            {
                output.Add(Team.Name);
            }
            return output;
        }

        // GET: api/TeamDetails/5
        [HttpGet("{team}", Name = "Get")]
        public IEnumerable<Person> Get(string team)
        {
            List<Person> members = new List<Person>();
            foreach (var person in Persons)
            {
                if (person.Team != null)
                {
                    if (person.Team.Name == team)
                    {
                        members.Add(person);
                    }
                }
            }
            return members;
        }

        // POST: api/TeamDetails
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            Persons.Add(person);
        }


    }
}
