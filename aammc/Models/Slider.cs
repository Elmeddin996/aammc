﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using aammc.Web.Attributes.ValidationAttributes;


namespace aammc.Models
{
    public class Slider
    {

        public int Id { get; set; }
		public int Order { get; set; }
        public string TitleAz { get; set; }
        public string TitleEn { get; set; }
        public string TitleRu { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionRu { get; set; }
        public string ButtonTextAz { get; set; }
        public string ButtonTextEn { get; set; }
        public string ButtonTextRu { get; set; }
		[MaxLength(250)]
        public string BtnUrl { get; set; }
		public string Image { get; set; }

        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Image2 { get; set; }

        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile2 { get; set; }

        public string Image3 { get; set; }

        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile3 { get; set; }

    }
}
