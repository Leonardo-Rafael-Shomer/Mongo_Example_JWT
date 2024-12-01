using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using MongoExample.Services;

namespace MongoExample.Controllers;

[Controller]
[Route("[controller]")]
public class 
    VisitorController(MongoDbService mongoDbService) : ControllerBase
{
    private readonly MongoDbService _mongoDBService = mongoDbService;

   
    [HttpGet]
    [Authorize]
    public async Task<List<Visitor>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Visitor visitor)
    {
        await _mongoDBService.CreateAsync(visitor);
        return CreatedAtAction(nameof(Get),new{id =visitor.Id}, visitor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVisitor(string id, [FromBody] Visitor visitor)
    {
        await _mongoDBService.UpdateVisitor(id, visitor);
        return Ok(visitor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisitor(string id,[FromBody] Visitor visitor)
    {
        await _mongoDBService.DeleteVisitor(id);
        return Ok(visitor);
    }
}