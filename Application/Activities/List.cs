using System;
using System.Threading.Tasks;
using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
  public class List
  {
    public class Query : IRequest<List<Activity>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Activity>>
    {
      public readonly DataContext _context;

      //public Handler(DataContext context, ILogger<List> logger)
      public Handler(DataContext context)
      {
        _context = context;

      }



      public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
      {

        // try
        // {
        //   for (int i = 0; i <= 10; i++)
        //   {
        //     cancellationToken.ThrowIfCancellationRequested();
        //     await Task.Delay(1000, cancellationToken);
        //     _logger.LogInformation($"Task {i} Going on...");


        //   }

        // }
        // catch (Exception ex) when (ex is TaskCanceledException)
        // {
        //   _logger.LogInformation("Task was Cancelled");
        // }
        //return await _context.Activities.ToListAsync(cancellationToken);
        return await _context.Activities.ToListAsync();
      }
    }
  }
}