using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallAssignmentService : AbstractCallAssignmentService, ICallAssignmentService
	{
		public CallAssignmentService(
			ILogger<ICallAssignmentRepository> logger,
			IMediator mediator,
			ICallAssignmentRepository callAssignmentRepository,
			IApiCallAssignmentServerRequestModelValidator callAssignmentModelValidator,
			IDALCallAssignmentMapper dalCallAssignmentMapper)
			: base(logger,
			       mediator,
			       callAssignmentRepository,
			       callAssignmentModelValidator,
			       dalCallAssignmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7cf2ffe6a910ee2cfd262c66d3dc441b</Hash>
</Codenesium>*/