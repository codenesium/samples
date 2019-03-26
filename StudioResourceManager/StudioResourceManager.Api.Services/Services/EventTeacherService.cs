using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class EventTeacherService : AbstractEventTeacherService, IEventTeacherService
	{
		public EventTeacherService(
			ILogger<IEventTeacherRepository> logger,
			IMediator mediator,
			IEventTeacherRepository eventTeacherRepository,
			IApiEventTeacherServerRequestModelValidator eventTeacherModelValidator,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base(logger,
			       mediator,
			       eventTeacherRepository,
			       eventTeacherModelValidator,
			       dalEventTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e8bee6a3a926b863ccc7c3a92d8d9d3e</Hash>
</Codenesium>*/