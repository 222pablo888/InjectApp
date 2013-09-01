using InjectApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InjectApp.Models
{
    public class InjectModel
    {
        [Display(Name = "InjectImageLink",ResourceType=typeof(LabelsResources))]
        public string InjectImageLink { get; set; }
        [Display(Name = "ImageLink", ResourceType = typeof(LabelsResources))]
        public string ImageLink { get; set; }
        [Display(Name = "EmailToSubmit", ResourceType = typeof(LabelsResources))]
        public string EmailToSumbit { get; set; }
    }
}