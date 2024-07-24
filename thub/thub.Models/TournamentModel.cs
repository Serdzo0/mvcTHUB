using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace thub.Models
{
    public class TournamentModel
    {
        [Key]
        public int TournamentId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Tournament Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Sport")]
        public string Sport { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Number of teams can not be 0")]
        [DisplayName("Select maximum number of teams")]
        public int NumberOfTeams { get; set; }
        [Required]
        [DisplayName("Select number of groups")]
        public int NumberOfGroups { get; set; }
        [Required]
        [DisplayName("Starting date")]
        [DataType(DataType.Date)]
        public DateOnly StartDate {  get; set; }
        [DisplayName("Add Teams")]
        public string[]? teams { get; set; } 
        public IdentityUser? User { get; set; }
        public string? userId { get; set; }
    }
}
