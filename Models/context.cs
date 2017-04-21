using Microsoft.EntityFrameworkCore;

namespace ProfessionalNetwork.Models
{
    public class ProfessionalPlannerContext : DbContext 
    {
        public ProfessionalPlannerContext(DbContextOptions<ProfessionalPlannerContext> options): base(options){}

        public DbSet<User> User {get;set;}
        public DbSet<Network> Network {get;set;}

    }
}