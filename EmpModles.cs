using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MK.StordProcedureMVC.Models
{
    public class EmpModles
    {
        [Required]
        public int? EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required ]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        public int? PinCode { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string DepCode { get; set; }
        [Required]
        public string DepName { get; set; }
        [Required]

        public int? AdressId { get; set; }
        [Required]
        public int? DeptId { get; set; }
        [Required]
        public string Village { get; set; }
        [Required]
        public string BuildingNo { get; set; } 
    }
}
