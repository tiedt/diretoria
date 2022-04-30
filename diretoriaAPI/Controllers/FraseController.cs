using diretoriaAPI.Models;
using diretoriaAPI.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace diretoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FraseController : ControllerBase
{
    private readonly FraseService _diretoriaService;

    public FraseController(FraseService diretoriaService) =>
        _diretoriaService = diretoriaService;

    [HttpGet]
    public async Task<List<FraseModel>> Get() =>
        await _diretoriaService.GetAsync();

    [HttpGet("GetById")]
    public async Task<ActionResult<FraseModel>> Get(Guid id)
    {
        var book = await _diretoriaService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FraseModel newFrase)
    {
        await _diretoriaService.CreateAsync(newFrase);

        return CreatedAtAction(nameof(Get), new { id = newFrase.Id }, newFrase);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, FraseModel updatedFrase)
    {
        var book = await _diretoriaService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedFrase.Id = book.Id;

        await _diretoriaService.UpdateAsync(id, updatedFrase);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _diretoriaService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _diretoriaService.RemoveAsync(id);

        return NoContent();
    }
}