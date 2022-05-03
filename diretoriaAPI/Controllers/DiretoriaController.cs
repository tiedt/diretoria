using diretoriaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using diretoriaAPI.Infrastructure.Interface;
using AutoMapper;
using diretoriaAPI.DTO;

namespace diretoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiretoriaController : ControllerBase
{
    private readonly IDiretoriaInterface _diretoriaInterface;
    private readonly IMapper _mapper;

    public DiretoriaController(IMapper mapper, IDiretoriaInterface diretoriaInterface)
    {
        _diretoriaInterface = diretoriaInterface;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<List<DiretoriaModel>> Get() =>
        await _diretoriaInterface.GetAsync();

    [HttpGet("GetById")]
    public async Task<ActionResult<DiretoriaModel>> Get(string id)
    {
        var book = await _diretoriaInterface.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DiretoriaDTO diretoria)
    {
        var mapper = _mapper.Map<DiretoriaModel>(diretoria);
        await _diretoriaInterface.CreateAsync(mapper);

        return CreatedAtAction(nameof(Get), new { id = mapper.Id }, mapper);
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, DiretoriaModel updatedDiretoria)
    {
        var book = await _diretoriaInterface.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedDiretoria.Id = book.Id;

        await _diretoriaInterface.UpdateAsync(id, updatedDiretoria);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        if (await _diretoriaInterface.GetAsync(id) is null) return NotFound();

        await _diretoriaInterface.RemoveAsync(id);

        return NoContent();
    }
}