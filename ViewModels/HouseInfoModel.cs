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

        [Required(ErrorMessage ="Nhập tên căn hộ")]
        [Display(Name="Tên căn hộ")]
        public string HouseName { get; set; }

        [Required(ErrorMessage = "Nhập hướng của căn hộ")]
        [Display(Name="Hướng nhà")]
        public string Direction { get; set; }

        [Required(ErrorMessage ="Nhập khu vực của căn hộ")]
        [Display(Name = "Khu vực")]
        public string HouseAreas { get; set; }


        [Required(ErrorMessage ="Nhập giá của căn hộ")]
        [Display(Name = "Giá")]
        public decimal HousePrice { get; set; }

        [Required(ErrorMessage ="Nhập diện tích của căn hộ")]
        [Display(Name ="Diện tích")]
        public decimal HouseAcreage { get; set; }

        [Required(ErrorMessage = "Tải ảnh của căn hộ")]
        [Display(Name = "Ảnh tiêu đề")]
        public IFormFile Thumbnail { get; set; }

        [Required(ErrorMessage = "Nhập mô tả cho căn hộ")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ảnh nền")]
        public IFormFile ImageBackground { get; set; }

        [Required(ErrorMessage = "Tải các hình ảnh của căn hộ")]
        [Display(Name = "Ảnh căn hộ")]
        public List<IFormFile> Images { get; set; }
    }
}
