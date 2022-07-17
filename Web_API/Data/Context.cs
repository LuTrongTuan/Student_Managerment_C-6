using Microsoft.EntityFrameworkCore;

namespace Web_API.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) {}

        
    }
}