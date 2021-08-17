using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Models
{
    public class Employee 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Photo { get; set; }
        [Display(Name = "Territorial Community")]
        public int TerritorialCommunityId { get; set; }
        [ForeignKey("TerritorialCommunityId")]
        public virtual TerritorialCommunity TerritorialCommunity { get; set; }

    }
}
