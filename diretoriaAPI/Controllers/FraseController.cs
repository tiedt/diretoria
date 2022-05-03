using diretoriaAPI.Models;
using diretoriaAPI.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using diretoriaAPI.Infrastructure.Interface;

namespace diretoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FraseController : ControllerBase
{
    private readonly IFraseInterface _fraseService;

    public FraseController(IFraseInterface fraseService) =>
        _fraseService = fraseService;

    [HttpGet]
    public async Task<List<FraseModel>> Get() =>
        await _fraseService.GetAsync();

    [HttpGet("GetById")]
    public async Task<ActionResult<FraseModel>> Get(string id)
    {
        var book = await _fraseService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FraseModel newFrase)
    {
        await _fraseService.CreateAsync(newFrase);

        return CreatedAtAction(nameof(Get), new { id = newFrase.Id }, newFrase);
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, FraseModel updatedFrase)
    {
        var book = await _fraseService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedFrase.Id = book.Id;

        await _fraseService.UpdateAsync(id, updatedFrase);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _fraseService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _fraseService.RemoveAsync(id);

        return NoContent();
    }
}