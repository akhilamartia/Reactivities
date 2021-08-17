using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Activities;
using MediatR;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ActivitiesController : BaseApiController
  {

    // [HttpGet]
    // public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    // {
    //   return await Mediator.Send(new List.Query(), ct);
    // }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity Activity)
    {
      return Ok(await Mediator.Send(new Create.Command { Activity = Activity }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity Activity)
    {
      Activity.Id = id;
      return Ok(await Mediator.Send(new Edit.Command { Activity = Activity }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
      return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }

  }
}