using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginalFrameWork4_7_2.Models
{
    [Table("Tb_Employee")]
    public class EmployeeModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Column("LastName")]
        public string LastName { get; set; } = string.Empty;

        [Column("Gender")]
        public string Gender { get; set; } = string.Empty;

        [Column("BirthDay")]
        public DateTime BirthDay { get; set; } = DateTime.Now;

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column("IsActive")]
        public Boolean IsActived { get; set; } = true;
    }
}