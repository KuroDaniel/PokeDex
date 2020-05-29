using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDex.Domain.Models
{
    //[Keyless]
    public class Creature_Types
    {
        public int CreatureId { get; set; }
        public Creatures Creatures { get; set; }

        public int TypeId { get; set; }
        public Typing Typing { get; set; }
    }
}
