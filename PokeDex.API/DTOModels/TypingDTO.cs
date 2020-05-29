using PokeDex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDex.API.DTOModels
{
    public class TypingDTO
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypePic { get; set; }
        public List<CreaturesDTO> Creatures { get; set; }
    }
}
