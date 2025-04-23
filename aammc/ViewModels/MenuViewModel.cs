using aammc.Models;

namespace aammc.ViewModels
{
	public class MenuViewModel
	{
		public Settings Settings { get; set; }
		public List<Project> Project { get; set; }
		public List<Equipment> Equipment { get; set; }
		public List<Transport> Transports { get; set; }
        public List<Slider> Slider { get; set; }	
		public List<Partner> Partners { get; set; }

    }
}
