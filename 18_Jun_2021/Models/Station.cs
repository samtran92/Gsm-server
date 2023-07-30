namespace _18_Jun_2021.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Station")]
    public partial class Station
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TargetStation { get; set; }

        public string StationInfo { get; set; }

        [StringLength(15)]
        public string PhoneNum { get; set; }
    }
}
