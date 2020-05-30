using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDex.Domain.DTOModels
{
    public class TypingDTO
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypePic { get; set; }
        public List<CreaturesDTO> Creatures { get; set; }
    }
}
