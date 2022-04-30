using diretoriaAPI.Models;
using diretoriaAPI.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace diretoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiretoriaController : ControllerBase
{
    private readonly DiretoriaService _diretoriaService;

    public DiretoriaController(DiretoriaService diretoriaService) =>
        _diretoriaService = diretoriaService;

    [HttpGet]
    public async Task<List<DiretoriaModel>> Get() =>
        await _diretoriaService.GetAsync();

    [HttpGet("GetById")]
    public async Task<ActionResult<DiretoriaModel>> Get(Guid id)
    {
        var book = await _diretoriaService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DiretoriaModel newDiretoria)
    {
        await _diretoriaService.CreateAsync(newDiretoria);

        return CreatedAtAction(nameof(Get), new { id = newDiretoria.Id }, newDiretoria);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, DiretoriaModel updatedDiretoria)
    {
        var book = await _diretoriaService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedDiretoria.Id = book.Id;

        await _diretoriaService.UpdateAsync(id, updatedDiretoria);

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