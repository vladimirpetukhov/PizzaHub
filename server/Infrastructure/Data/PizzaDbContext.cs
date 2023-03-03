namespace server.Infrastructure.Data
{
    #region usings
    using Microsoft.EntityFrameworkCore;
    #endregion

    public class PizzaDbContext: DbContext
    {
        #region ctor
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options): base(options) { }
        #endregion
    }
}
