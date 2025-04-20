using aammc.DAL;
using aammc.Models;

namespace aammc.Services
{
    public class LayoutService
    {
        private readonly AammcDbContext _contex;

        public LayoutService(AammcDbContext contex)
        {
            _contex = contex;
        }

        public List<Settings> GetSettings()
        {
            return _contex.Settings.ToList();
        }
        public List<Project> GetProject()
        {
            return _contex.Projects.ToList();
        }
    }
}
