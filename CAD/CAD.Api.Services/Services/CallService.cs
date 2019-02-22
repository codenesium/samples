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
			IDALNoteMapper dalNoteMapper,
			IDALCallAssignmentMapper dalCallAssignmentMapper)
			: base(logger,
			       mediator,
			       callRepository,
			       callModelValidator,
			       dalCallMapper,
			       dalNoteMapper,
			       dalCallAssignmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a7264e8e58e4f51e509708bab35c7b4</Hash>
</Codenesium>*/