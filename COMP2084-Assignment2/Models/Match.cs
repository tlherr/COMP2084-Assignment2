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

        [Display(Name ="Win")]
        public bool result { get; set; }

        [Display(Name = "Match Notes")]
        [Column(TypeName = "text")]
        public string notes { get; set; }
        [Display(Name = "Arena")]
        [Required(ErrorMessage = "Arena is Required")]
        public int map { get; set; }
        [Display(Name = "Opponent")]
        [Required(ErrorMessage = "Opponent is Required")]
        public int opponent_one { get; set; }
        [Display(Name = "Opponent")]
        [Required(ErrorMessage = "Opponent is Required")]
        public int opponent_two { get; set; }

        [StringLength(128)]
        public string user_id { get; set; }
        public virtual Class Class { get; set; }
        public virtual Class Class1 { get; set; }
        public virtual Map Map1 { get; set; }
    }
}
