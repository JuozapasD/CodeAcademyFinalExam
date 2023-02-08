namespace CodeAcademyFinalExam.DAL
{
    public class JwtRepository : IJwtRepository
    {
        readonly AccountsRegistrationDbContext _context;

        public JwtRepository(AccountsRegistrationDbContext context)
        {
            _context = context;
        }

        public Account GetAccount(string username)
            {
                return _context.Accounts.FirstOrDefault(A => A.Username == username);
            }

            public void SaveAccount(Account account)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
        }
}
// persivadint i acc