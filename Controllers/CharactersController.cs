using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace C__prosjektoppgave;
[ApiController]
[Route("api/characters")]

public class _CharactersController : ControllerBase
{
    private readonly AppDbContext _context;

    public _CharactersController(AppDbContext context)
    {
        _context = context;
        if (!_context.Characters.Any())
        {
            _context.Characters.Add(new Characters { Id = 6, Name = "Umi", Age = 16, Film = "From up on Poppy Hill", About = "lorem ipsum" });
            _context.SaveChanges();
        }
    }
    private static List<Characters> characters = new List<Characters>{
        new Characters {Id = 1, Name = "Chihiro", Age = 10, Film = "Spirited Away", About = "Chihiro is the main character of the movie Spirited Away. She and her parents ends up walking into the spirit world, and she has to work for the witch Yubaba in order to save her parents who were turned into pigs."},
        new Characters {Id = 2, Name = "San", Age = 17, Film = "Princess Mononoke", About = "San is one of the main characters of Princess Mononoke, and the one the movie is named after. She was raised by wolves in the forest, and works together with them and Ashitaka, the other main character, to try and save the forest and the spirit God."},
        new Characters {Id = 3, Name = "Sophie", Age = 18, Film = "Howl's Moving Castle", About = "lorem ipsum"},
        new Characters {Id = 4, Name = "Sheeta", Age = 13, Film = "Laputa: Castle In The Sky", About = "lorem imspun"},
        new Characters {Id = 5, Name = "Nausicaä", Age = 16, Film = "Nausicaä of the Valley of the Wind", About = "lorem ipsum"}
    };

    // public _CharactersController(AppDbContext context)
    // {
    //     _context = context;
    //     if (!_context.Characters.Any())
    //     {
    //         _context.Characters.AddRange(characters);
    //         _context.SaveChanges();
    //     }
    // }

    // create the GET endpoint
    [HttpGet]
    public ActionResult<IEnumerable<Characters>> GetCharacters()
    {
        return _context.Characters.ToList();
    }

    //create the POST endpoint
    [HttpPost]
    public IActionResult Post([FromBody] Characters characters)
    {
        if (characters == null)
        {
            return BadRequest("Client error occured!");
        }
        _context.Add(characters);
        _context.SaveChanges();
        //characters.Add(characters);
        return CreatedAtAction(nameof(Post), new
        {
            Id = characters.Id,
            Name = characters.Name,
            Age = characters.Age,
            Film = characters.Film,
            About = characters.About
        }, characters);
    }






}
