using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class EventStudentService : AbstractEventStudentService, IEventStudentService
	{
		public EventStudentService(
			ILogger<IEventStudentRepository> logger,
			IMediator mediator,
			IEventStudentRepository eventStudentRepository,
			IApiEventStudentServerRequestModelValidator eventStudentModelValidator,
			IDALEventStudentMapper dalEventStudentMapper)
			: base(logger,
			       mediator,
			       eventStudentRepository,
			       eventStudentModelValidator,
			       dalEventStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1d0bfed6f68c933c3a4a66b23e714914</Hash>
</Codenesium>*/