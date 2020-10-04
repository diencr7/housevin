using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseVin.Data
{
    public class t_houseInfo
    {
        [Key]
        public int Id { get; set; }

        public string HouseName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HousePrice { get; set; }

        public string HouseAreas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HouseAcreage { get; set; }

        public string Imgages { get; set; }

        public string Description { get; set; }

        public string ImageBackground { get; set; }

        public string Thumbnail { get; set; }

        public string Direction { get; set; }

        public bool DelFlg { get; set; }
    }
}
