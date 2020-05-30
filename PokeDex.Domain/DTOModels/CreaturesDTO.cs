using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDex.Domain.DTOModels
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
