namespace _18_Jun_2021.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string MessageTitle { get; set; }

        [Required]
        public string MessageContent { get; set; }

        [StringLength(50)]
        public string ToStation { get; set; }

        [StringLength(50)]
        public string PosterName { get; set; }

        public DateTime? Date { get; set; }

        public int? Count { get; set; }
    }
}
