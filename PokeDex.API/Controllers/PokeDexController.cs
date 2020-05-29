using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using PokeDex.API.DTOModels;
using PokeDex.Data;
using PokeDex.Domain.Models;

namespace PokeDex.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class PokeDexController : ControllerBase
    {
        private static PokeDexContext context = new PokeDexContext();

        [HttpGet]
        [Route("api/[controller]/GetAllPokemon")]
        public List<CreaturesDTO> GetAllPokemon()
        {
            //List<Creatures> creatures = new List<Creatures>();

            //return context.Creatures.ToList();

            //return context.Creatures.Include(c => c.Creature_Types).ThenInclude(ct => ct.Typing).ToList();


            var list = new List<CreaturesDTO>();

            list = (from c in context.Creatures
                    select new CreaturesDTO
                    {
                        CreatureId = c.CreatureId,
                        Name = c.Name,
                        CreaturePic = c.CreaturePic,
                        DexNum = c.DexNum,

                        Types = (from t in context.Typing
                                 join ct in context.Creature_Type on t.TypeId equals ct.TypeId
                                 where ct.CreatureId == c.CreatureId
                                 select new TypingDTO
                                 {
                                     TypeId = t.TypeId,
                                     TypeName = t.TypeName,
                                     TypePic = t.TypePic
                                 }).ToList()
                    }).OrderBy(p => p.DexNum).ToList();

            //return Json(new { data = list.ToList() });

            return list;
        }

        [HttpGet]
        [Route("api/[controller]/GetAllTypes")]
        public List<TypingDTO> GetAllTypes()
        {
            //return context.Typing.ToList();

            //return context.Typing.Include(ct => ct.Creature_Types).ThenInclude(t => t.Creatures).ToList();

            var list = new List<TypingDTO>();

            list = (from t in context.Typing
                    select new TypingDTO
                    {
                        TypeId = t.TypeId,
                        TypeName = t.TypeName,
                        TypePic = t.TypePic,
                        Creatures = (from c in context.Creatures
                                 join ct in context.Creature_Type on c.CreatureId equals ct.CreatureId
                                 where ct.TypeId == t.TypeId
                                 select new CreaturesDTO
                                 {
                                     CreatureId = c.CreatureId,
                                     Name = c.Name,
                                     CreaturePic = c.CreaturePic,
                                     DexNum = c.DexNum
                                 }).ToList()
                    }).ToList();
            return list;
        }

        //public CreaturesDTO DeletePokemon()
        //{
        //    return null;
        //}

        [HttpGet]
        [Route("api/[controller]/PokemonDetails/{id}")]
        public CreaturesDTO PokemonDetails(int id)
        {
            
            //var pokemon = context.Creatures.Find(id);
            var pokemon = (from c in context.Creatures where c.CreatureId == id
                           select new CreaturesDTO
                           {
                               CreatureId = c.CreatureId,
                               Name = c.Name,
                               CreaturePic = c.CreaturePic,
                               DexNum = c.DexNum,

                               Types = (from t in context.Typing
                                        join ct in context.Creature_Type on t.TypeId equals ct.TypeId
                                        where ct.CreatureId == c.CreatureId
                                        select new TypingDTO
                                        {
                                            TypeId = t.TypeId,
                                            TypeName = t.TypeName,
                                            TypePic = t.TypePic
                                        }).ToList()
                           }).FirstOrDefault();
            return pokemon;

        }
        [HttpPost]
        [Route("api/[controller]/AddPokemon")]
        public bool AddPokemon(CreaturesDTO creature)
        {
            try
            {
                Creatures newCreature = new Creatures();

                newCreature.CreaturePic = creature.CreaturePic;
                newCreature.DexNum = creature.DexNum;
                newCreature.Name = creature.Name;

                context.Creatures.Add(newCreature);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        [HttpPost]
        [Route("api/[controller]/EditPokemon")]
        public bool EditPokemon(CreaturesDTO creature)
        {
            try
            {
                Creatures creatureToEdit = context.Creatures.Find(creature.CreatureId);

                creatureToEdit.CreaturePic = creature.CreaturePic;
                creatureToEdit.DexNum = creature.DexNum;
                creatureToEdit.Name = creature.Name;


                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

            
        }

        [HttpDelete]
        [Route("api/[controller]/DeletePokemon/{id}")]
        public bool DeletePokemon(int id)
        {
            try
            {
                Creatures pokemonToDelete = context.Creatures.Find(id);

                context.Creatures.Remove(pokemonToDelete);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}