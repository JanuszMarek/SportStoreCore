using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessons.Areas.DependencyInjection.Models;

namespace Lessons.Areas.DependencyInjection.Infrastructure
{
    public static class TypeBroker
    {
        /*     
        TypeBroker  class defines a  Repository  property that returns new objects that implement the
        IRepository  interface. The implementation class used by the  Repository  property is determined by the
        value of the  repoType  field, which defaults to  MemoryRepository  but which can be changed by calling the
        SetRepositoryTypemethod. 
        */

        private static Type repoType = typeof(MemoryRepository);
        private static IRepository testRepo;

        public static IRepository Repository => testRepo ?? Activator.CreateInstance(repoType) as IRepository;

        public static void SetRepositoryType<T>() where T : IRepository => repoType = typeof(T);

        public static void SetTestObject(IRepository repo)
        {
            testRepo = repo;
        }
    }
}
