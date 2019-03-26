using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IMediator mediator,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IDALEventMapper dalEventMapper,
			IDALEventStudentMapper dalEventStudentMapper,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base(logger,
			       mediator,
			       eventRepository,
			       eventModelValidator,
			       dalEventMapper,
			       dalEventStudentMapper,
			       dalEventTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>825addbd6680a546a59bc77a90eba84a</Hash>
</Codenesium>*/