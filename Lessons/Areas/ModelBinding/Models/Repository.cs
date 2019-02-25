using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.ModelBinding.Models
{
    public interface IBindRepository
    {
        IEnumerable<PersonBind> People { get; }
        PersonBind this[int id] { get; set; }
    }

    public class MemoryBindRepository : IBindRepository
    {
        private Dictionary<int, PersonBind> people = new Dictionary<int, PersonBind>
                    {
                        [1] = new PersonBind
                        {
                            PersonId = 1,
                            FirstName = "Bob",
                            LastName = "Smith",
                            Role = Role.Admin
                        },
                        [2] = new PersonBind
                        {
                            PersonId = 2,
                            FirstName = "Anne",
                            LastName = "Douglas",
                            Role = Role.User
                        },
                        [3] = new PersonBind
                        {
                            PersonId = 3,
                            FirstName = "Joe",
                            LastName = "Able",
                            Role = Role.User
                        },
                        [4] = new PersonBind
                        {
                            PersonId = 4,
                            FirstName = "Mary",
                            LastName = "Peters",
                            Role = Role.Guest
                        }
                    };

        public IEnumerable<PersonBind> People => people.Values;

        public PersonBind this[int id]
        {
            get
            {
                return people.ContainsKey(id) ? people[id] : null;
            }
            set
            {
                people[id] = value;
            }
        }
    }

}
