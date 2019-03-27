using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>a8abed95906f2fae5aa379d1dd5f53c3</Hash>
</Codenesium>*/