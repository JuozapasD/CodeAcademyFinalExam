using Microsoft.EntityFrameworkCore;

namespace CodeAcademyFinalExam
{
    public class AccountsRegistrationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<HumanInformation> HumanInformation { get; set; }

        public AccountsRegistrationDbContext(DbContextOptions<AccountsRegistrationDbContext> options) : base(options)
        {

        }
    }
}
