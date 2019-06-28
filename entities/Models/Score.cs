using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.entities.Models
{
    [Table("scores")]
    public class Score : IEntity
    {
        [Key]
        [Column("ScoreId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Weapon is required")]
        public string Weapon { get; set; }

        [Required(ErrorMessage = "Nickname is required")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public int TheScore { get; set; }
    }
}
