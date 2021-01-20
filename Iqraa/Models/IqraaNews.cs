using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iqraa.Models
{
    public class IqraaNews
    {
        public int Id { get; set; }

        public string TitleAr { get; set; }

        public string TitleEn { get; set; }

        public string TitleFr { get; set; }

        public string TitleEs { get; set; }

        public string TitleUr { get; set; }

        [AllowHtml]
        public string DescAr { get; set; }

        [AllowHtml]
        public string DescEn { get; set; }

        [AllowHtml]
        public string DescFr { get; set; }

        [AllowHtml]
        public string DescEs { get; set; }

        [AllowHtml]
        public string DescUr { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}