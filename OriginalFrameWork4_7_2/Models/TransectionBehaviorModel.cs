using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OriginalFrameWork4_7_2.Models
{
    [Table("TBL_TRN_BEHAVIOR")]
    public class TransectionBehaviorModel
    {
        [Key]
        [Column("TRN_ID")]
        
        public long TrnID { get; set; }

        [Column("TRN_DATE")]
        public DateTime TrnDate { get; set; }

        [Column("TRN_MOBILE_SECTION")]
        public string TrnMobileSection { get; set; }

        [Column("TRN_ATM_CDM_SECTION")]
        public string TrnATM_CDMSection { get; set;}

        [Column("TRN_COUNTER_SECTION")]
        public string TrnCouterSection { get;set; }

        [Column("ISACTIVED")]
        public bool IsActived { get; set; } = true;

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}