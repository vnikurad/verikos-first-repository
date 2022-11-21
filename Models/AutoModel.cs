using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AldagiTPL.Models
{
    [Table("AutoModels", Schema = "Claim")]
    [Index("AutoMarkId", Name = "iAutoMarkID_Claim_AutoModels_62C73DAE")]
    [Index("Gcrecord", Name = "iGCRecord_Claim_AutoModels_FEA81E75")]
    [Index("MarkId", Name = "iMarkID_Claim_AutoModels_52BDC9AF")]
    public partial class AutoModel
    {
        [Key]
        [Column("AutoModelID")]
        public int AutoModelId { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }
        [Column("AutoMarkID")]
        public int AutoMarkId { get; set; }
        [Column("MarkID")]
        public int? MarkId { get; set; }
        [Column("GCRecord")]
        public int? Gcrecord { get; set; }
    }
}
