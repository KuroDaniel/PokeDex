using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PokeDex.Domain.Models
{
    public class Creatures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public string CreaturePic { get; set; }
        public int DexNum { get; set; }

        [NotMapped]
        public List<Creature_Types> Creature_Types { get; } = new List<Creature_Types>();
    }
}
  