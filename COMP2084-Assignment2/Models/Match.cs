namespace COMP2084_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public byte result { get; set; }

        [Column(TypeName = "text")]
        public string notes { get; set; }

        [StringLength(20)]
        public string map { get; set; }

        public int opponent_1 { get; set; }

        public int opponent_2 { get; set; }

        public virtual Opponent Opponent { get; set; }

        public virtual Opponent Opponent1 { get; set; }
    }
}
