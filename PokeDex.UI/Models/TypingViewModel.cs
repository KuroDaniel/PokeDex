using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDex.UI.Models
{
    public class TypingViewModel
    {
        public int TypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
        public string TypePic { get; set; }
        public List<CreaturesViewModel> Creatures { get; set; }
    }
}
