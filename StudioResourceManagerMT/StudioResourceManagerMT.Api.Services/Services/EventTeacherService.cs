using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>0b2492bad3dd5aa307229e6fc6621fc4</Hash>
</Codenesium>*/