using aammc.Web.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace aammc.Models
{
	public class Project
	{
		public int Id { get; set; }
		public string TitleAz { get; set; }
		public string TitleEn { get; set; }
		public string TitleRu { get; set; }
		public string DescriptionAz { get; set; }
		public string DescriptionEn { get; set; }
		public string DescriptionRu { get; set; }
		public string Image { get; set; }
		[MaxFileSize(2097152)]
		[AllowedFileTypes("image/jpeg", "image/png")]
		[NotMapped]
		public IFormFile ImageFile { get; set; }

	}
}
