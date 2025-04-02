﻿using aammc.Web.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace aammc.Models
{
	public class Equipment
	{
		public int Id { get; set; }
		public string NameAz { get; set; }
		public string NameEn { get; set; }
		public string NameRu { get; set; }
        public string Image { get; set; }
		[MaxFileSize(2097152)]
		[AllowedFileTypes("image/jpeg", "image/png")]
		[NotMapped]
		public IFormFile ImageFile { get; set; }
	}
}
