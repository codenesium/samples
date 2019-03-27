using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallService : AbstractCallService, ICallService
	{
		public CallService(
			ILogger<ICallRepository> logger,
			IMediator mediator,
			ICallRepository callRepository,
			IApiCallServerRequestModelValidator callModelValidator,
			IDALCallMapper dalCallMapper,
			IDALCallAssignmentMapper dalCallAssignmentMapper,
			IDALNoteMapper dalNoteMapper)
			: base(logger,
			       mediator,
			       callRepository,
			       callModelValidator,
			       dalCallMapper,
			       dalCallAssignmentMapper,
			       dalNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ed7248efd22e5133ce4907c802760814</Hash>
</Codenesium>*/