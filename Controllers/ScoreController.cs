using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spraynprayscore.api.Contracts;
using spraynprayscore.api.entities.Extensions;
using spraynprayscore.api.entities.Models;

namespace spraynprayscore.api.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;

        public ScoreController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "ScoreById")]
        public IActionResult GetScoreById(Guid id)
        {
            try
            {
                var score = _repository.Score.GetScoreById(id);
                if (score.IsEmptyObject())
                {
                    _logger.LogError($"Score with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned scored with id: {id}");
                    return Ok(score);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetScoreById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetTopScores()
        {
            try
            {
                ArrayList weaponList = new ArrayList();
                string[] weapons = new string[] { "Spitfire", "Devotion with turbocharger", "Devotion without turbocharger", "R99", "Alternator", "R301", "Flatline", "Havoc with turbocharger", "Havoc without turbocharger", "Re45" };
                for(int i = 0; i < weapons.Length; i++)
                {
                    var returnedWeapon = _repository.Score.GetTopScoreByWeapon(weapons[i]);
                    returnedWeapon.Id = Guid.Empty;
                    weaponList.Add(returnedWeapon);
                }
                return Ok(weaponList);
                    
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTopScores action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateScore([FromBody] Score score)
        {
            try
            {
                if (score.IsObjectNull())
                {
                    _logger.LogError("Score object sent from client is null.");
                    return BadRequest("Score object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid score object sent from client.");
                    return BadRequest("Invalid object model");
                }

                _repository.Score.CreateScore(score);
                _repository.Save();

                return CreatedAtRoute("ScoreById", new { id = score.Id }, score);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateScore action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}