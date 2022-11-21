using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AldagiTPL.Models
{
    [Table("AutoMarks", Schema = "Claim")]
    [Index("Gcrecord", Name = "iGCRecord_Claim_AutoMarks_0C38D723")]
    public partial class AutoMark
    {
        [Key]
        [Column("AutoMarkID")]
        public int AutoMarkId { get; set; }
        [StringLength(255)]
        public string? Title { get; set; }
        [Column("GCRecord")]
        public int? Gcrecord { get; set; }
        public int? ClassifId { get; set; }
    }
}
