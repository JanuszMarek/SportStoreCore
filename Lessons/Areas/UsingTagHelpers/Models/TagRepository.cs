using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.UsingTagHelpers.Models
{

    public interface ITagRepository
    {
        IEnumerable<TagCity> Cities { get; }
        void AddCity(TagCity newCity);
    }

    public class MemoryTagRepository : ITagRepository
    {
        private List<TagCity> cities = new List<TagCity> {
            new TagCity { Name = "London", Country = "UK", Population = 8539000},
            new TagCity { Name = "New York", Country = "USA", Population = 8406000 },
            new TagCity { Name = "San Jose", Country = "USA", Population = 998537 },
            new TagCity { Name = "Paris", Country = "France", Population = 2244000 }
    };
        public IEnumerable<TagCity> Cities => cities;
        public void AddCity(TagCity newCity)
        {
            cities.Add(newCity);
        }
    }

    
}
