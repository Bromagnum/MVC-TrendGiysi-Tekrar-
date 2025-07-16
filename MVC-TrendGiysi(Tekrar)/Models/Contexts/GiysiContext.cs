using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_TrendGiysi_Tekrar_.Models.Entities;

namespace MVC_TrendGiysi_Tekrar_.Models.Contexts
{
    public class GiysiContext: IdentityDbContext<AppUser, AppUserRole, string>
    {
        public GiysiContext(DbContextOptions<GiysiContext> options) : base(options)
        {
        }

    }
   
        

    
}
