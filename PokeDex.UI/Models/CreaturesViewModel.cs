using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDex.UI.Models
{
    public class CreaturesViewModel
    {
        public int CreatureId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string CreaturePic { get; set; }
        public int DexNum { get; set; }
        public List<TypingViewModel> Types { get; set; }

        public int? TypeId1 { get; set; }
        
        public int? TypeId2 { get; set; }
    }
}
