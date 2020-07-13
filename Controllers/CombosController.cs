using System;
using System.Collections.Generic;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using BurgerShack.Models;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ComboController : ControllerBase
  {
    private readonly ComboService _service;
    private readonly ComboService _comboService;


    public ComboController(ComboService service, ComboService cs)
    {
      _service = service;
      _comboService = cs;
    }

    [HttpGet]  // GETALL
    public ActionResult<IEnumerable<DbCombo>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpGet("{id}")] // GETBYID
    public ActionResult<DbCombo> Get(int id)
    {
      try
      {
        return Ok(_service.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost] // POST
    public ActionResult<DbCombo> Create([FromBody] DbCombo newDbCombo)
    {
      try
      {
        return Ok(_service.Create(newDbCombo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")] // PUT

    public ActionResult<DbCombo> Edit([FromBody] DbCombo editDbCombo, int id)
    {
      try
      {
        editDbCombo.Id = id;
        return Ok(_service.Edit(editDbCombo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")] // DELETE
    public ActionResult<DbCombo> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
