using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>1b77551fbc57f104f99c36f0ddf7b05d</Hash>
</Codenesium>*/