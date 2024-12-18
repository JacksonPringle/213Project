using TheDogApp.Data;

namespace TheDogApp
{
    public class SiteUserService
    {
        private readonly TheDogAppContext _context;


        public SiteUserService(TheDogAppContext context)
        {
            _context = context;
        }

        public List<SiteUser> GetSiteUserList()
        {
            return _context.SiteUser.ToList();
        }
    }
}
