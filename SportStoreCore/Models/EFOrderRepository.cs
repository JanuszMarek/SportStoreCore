using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStoreCore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
        
        public void SaveOrder(Order order)
        {
            /*
                When the user’s cart
                data is de-serialized from the session store, the JSON package creates new objects that are created
                that are not known to Entity Framework Core, which then tries to write all of the objects into the
                database. For the  Product  objects, this means that EF Core tries to write objects that have already been
                stored, which causes an error. To avoid this problem, I notify Entity Framework Core that the objects
                exist and shouldn’t be stored in the database unless they are modified, as follows
            */
            context.AttachRange(order.Lines.Select(l => l.Product));

            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
