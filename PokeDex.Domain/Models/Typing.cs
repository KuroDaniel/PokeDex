using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PokeDex.Domain.Models
{
    public class Typing
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypePic { get; set; }

        //[NotMapped]
        public List<Creature_Types> Creature_Types { get; } = new List<Creature_Types>();


    }
}
