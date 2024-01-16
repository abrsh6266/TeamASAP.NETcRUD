using Microsoft.AspNetCore.Mvc;
using NewApi.Models;
using NewWeb.Services;

namespace NewWen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController: ControllerBase{
    private readonly TeamService teamService;
    public TeamsController(TeamService mongoDBService){
        teamService = mongoDBService;
    }
    
    [HttpGet]
    [Route("GetBestTeam")]
    public IActionResult Get(){
        var teams = teamService?.Get();
        return Ok(teams);
    }
    [HttpGet("{id:int}")]
    public IActionResult Get(string id){
        var team = teamService?.Get(id);
        if(team == null)
            return BadRequest("Invalid Id");
        return Ok(team);
    }
    [HttpPost]
    public IActionResult Post(Team team){
        teamService?.Create(team);
        return CreatedAtAction("Get",team.Id,team);
    }
    [HttpPatch]
    public IActionResult Patch(string id, string country){
        var team = teamService?.Get(id);
        if(team == null)
            return BadRequest("invalid Id");
        teamService?.Update(id,country);
        return NoContent();
    }
    [HttpDelete]
    public IActionResult Delete(string id){
         var team = teamService?.Get(id);
        if(team == null)
            return BadRequest("invalid Id");
        teamService?.Delete(id);
        return NoContent();
    }
}