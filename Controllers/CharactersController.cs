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
        new Characters {Id = 1, Name = "Chihiro", Age = 10, Film = "Spirited Away", About = "A young girl who just had to move from all her friends, Chihiro is timid and scared when she and her parents end up visiting the spirit world on accident. When her parents are turned into pigs, Chihiro has to find her own courage in order to save them, and ends up reconnecting with an old friend along the way."},
        new Characters {Id = 2, Name = "San", Age = 17, Film = "Princess Mononoke", About = "San is a young woman who was raised by the wolves and fights alongside them to protect the forest. Initially rejecting her own humanity, she comes to appreciate it while working alongside Ashitaka to save the forest spirit."},
        new Characters {Id = 3, Name = "Sophie", Age = 18, Film = "Howl's Moving Castle", About = "A young woman cursed to turn into an old woman. She goes in search of Howl's moving castle in order to break her spell, and finds her self-confidence along the way. "},
        new Characters {Id = 4, Name = "Sheeta", Age = 13, Film = "Laputa: Castle In The Sky", About = "Sheeta is unknowingly the last heir to the throne of a kingdom floating in the sky named Laputa. Escaping from the government, she works together with both Pazu and a band of air pirates in order to save both herself and what is left of her kingdom from falling into the wrong hands."},
        new Characters {Id = 5, Name = "Nausicaä", Age = 16, Film = "Nausicaä of the Valley of the Wind", About = "Nausicaä is known as the princess who loves insects, a remarkable trait for someone growing up in a polluted world where insects are one of the great dangers. She works to find a cure to the miasma poison which many of her people suffer from, and becomes entangled in a war between humans and animals in the process. "}
    };

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
