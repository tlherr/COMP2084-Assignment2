namespace COMP2084_Assignment2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        public int id { get; set; }

        public bool result { get; set; }

        [Column(TypeName = "text")]
        public string notes { get; set; }

        public int map { get; set; }

        public int opponent_one { get; set; }

        public int opponent_two { get; set; }

        [Required]
        [StringLength(128)]
        public string user_id { get; set; }

        public virtual Class Class { get; set; }

        public virtual Class Class1 { get; set; }

        public virtual Map Map1 { get; set; }
    }
}
