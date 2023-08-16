using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Identity.Data
{
    public class DbInitializer
    {
        public static void Initializer(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
