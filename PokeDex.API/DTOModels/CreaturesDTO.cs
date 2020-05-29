using PokeDex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDex.API.DTOModels
{
    public class CreaturesDTO
    {
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public string CreaturePic { get; set; }
        public int DexNum { get; set; }
        public List<TypingDTO> Types { get; set; }

    }
}
