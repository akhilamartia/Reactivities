using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
  public class Edit
  {
    public class Command : IRequest
    {
      public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var activity = await _context.Activities.FindAsync(request.Activity.Id);
        _mapper.Map(request.Activity, activity);

        //         {
        //           "id": "dbcc03cc-c90c-4881-8825-f7cdc4d26262",
        //     "title": "Test Create Activity",
        //     "date": "2021-08-30T19:19:55.836",
        //     "description": "Description of the test event",
        //     "category": "Culture",
        //     "city": "London",
        //     "venue": "Tower of London"
        // }
        // _context.Activities.Update(request.Activity);
        await _context.SaveChangesAsync();
        return Unit.Value;

      }
    }


  }
}