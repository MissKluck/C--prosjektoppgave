using Microsoft.AspNetCore.Mvc;

namespace C__prosjektoppgave;
[ApiController]
[Route("api/characters")]

public class CharactersController : ControllerBase
{
    private static List<Characters> characters = new List<Characters>{
        new Characters {Id = 1, Name = "Chihiro", Age = 10, Film = "Spirited Away", About = "Chihiro is the main character of the movie Spirited Away. She and her parents ends up walking into the spirit world, and she has to work for the witch Yubaba in order to save her parents who were turned into pigs."},
        new Characters {Id = 2, Name = "San", Age = 17, Film = "Princess Mononoke", About = "San is one of the main characters of Princess Mononoke, and the one the movie is named after. She was raised by wolves in the forest, and works together with them and Ashitaka, the other main character, to try and save the forest and the spirit God."},
        new Characters {Id = 3, Name = "Sophie", Age = 18, Film = "Howl's Moving Castle", About = "lorem ipsum"},
        new Characters {Id = 4, Name = "Sheeta", Age = 13, Film = "Laputa: Castle In The Sky", About = "lorem imspun"},
        new Characters {Id = 5, Name = "Nausicaä", Age = 16, Film = "Nausicaä of the Valley of the Wind", About = "lorem ipsum"},
        new Characters {Id = 6, Name = "Umi", Age = 16, Film = "From up on Poppy Hill", About = "lorem ipsum"}
    };

    // create the GET endpoint
    [HttpGet]
    public IEnumerable<Characters> Get()
    {
        return characters;
    }

    //create the POST endpoint
    [HttpPost]
    public IActionResult Post([FromBody] Characters _characters)
    {
        if (_characters == null)
        {
            return BadRequest("Client error occured!");
        }
        characters.Add(_characters);
        return CreatedAtAction(nameof(Post), new
        {
            Id = _characters.Id,
            Name = _characters.Name,
            Age = _characters.Age,
            Film = _characters.Film,
            About = _characters.About
        }, characters);
    }






}
