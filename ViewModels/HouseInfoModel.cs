using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HouseVin.ViewModels
{
    public class HouseInfoModel
    {
        public HouseInfoModel()
        {
        }

        [Required(ErrorMessage ="Please enter name of house")]
        [Display(Name="House Name")]
        public string HouseName { get; set; }

        [Required(ErrorMessage = "Please enter direction of house")]
        [Display(Name="House Direction")]
        public string Direction { get; set; }

        [Required(ErrorMessage ="Please enter area of house")]
        [Display(Name = "House Area")]
        public string HouseAreas { get; set; }


        [Required(ErrorMessage ="Please enter price of house")]
        [Display(Name = "Price")]
        public decimal HousePrice { get; set; }

        [Required(ErrorMessage ="Please enter acreage of house")]
        [Display(Name ="Acreage")]
        public decimal HouseAcreage { get; set; }

        [Required(ErrorMessage = "Please upload image thumbnail of house")]
        [Display(Name = "Image Thumbnail")]
        public IFormFile Thumbnail { get; set; }

        [Required(ErrorMessage = "Please enter description of house")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image backgroud")]
        public IFormFile ImageBackground { get; set; }

        [Required(ErrorMessage = "Please upload images of house")]
        [Display(Name = "House Image")]
        public List<IFormFile> Images { get; set; }
    }
}
