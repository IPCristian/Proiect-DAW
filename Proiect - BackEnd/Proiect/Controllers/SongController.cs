using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Model.Entities;
using Proiect.Model.Entities.DTOs;
using Proiect.Repositories.SongRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _repository;

        public SongController(ISongRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize(Roles = "StandardUser")]
        public async Task<IActionResult> GetAllSongs()
        {
            var allSongs = await _repository.GetAllSongs();

            var songsToReturn = new List<SongDTO>();

            foreach (var song in allSongs)
            {
                songsToReturn.Add(new SongDTO(song));
            }

            return Ok(songsToReturn);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _repository.GetById(id);
            return Ok(new SongDTO(song));
        }

        /*[HttpGet("{artistName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSongsByAnArtist(string artistName)
        {
            var songs = await _repository.GetSongsFromArtist(artistName);

            var songsToReturn = new List<SongDTO>();

            foreach (var song in songs)
            {
                songsToReturn.Add(new SongDTO(song));
            }

            return Ok(songsToReturn);
        }*/

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeGenre(int id,string genre)
        {
            var song = await _repository.GetById(id);
            
            if (song == null)
            {
                return NotFound("The specified ID isn't attributed to any of the songs.");
            }

            song.Genre = genre;

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateNewSong(CreateSongDTO dto)
        {
            Song newSong = new Song();

            newSong.ArtistName = dto.ArtistName;
            newSong.Genre = dto.Genre;
            newSong.Name = dto.Name;

            _repository.Create(newSong);

            await _repository.SaveAsync();

            return Ok(new SongDTO(newSong));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSongById(int id)
        {
            var song = await _repository.GetById(id);
    
            if (song == null)
            {
                return NotFound("The specified ID isn't attributed to any of the songs.");
            }

            _repository.Delete(song);

            await _repository.SaveAsync();

            return NoContent();

        }
    }
}
