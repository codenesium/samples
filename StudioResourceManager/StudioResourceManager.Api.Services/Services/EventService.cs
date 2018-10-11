using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IEventRepository eventRepository,
			IApiEventRequestModelValidator eventModelValidator,
			IBOLEventMapper boleventMapper,
			IDALEventMapper daleventMapper,
			IBOLEventStudentMapper bolEventStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper,
			IBOLEventTeacherMapper bolEventTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base(logger,
			       eventRepository,
			       eventModelValidator,
			       boleventMapper,
			       daleventMapper,
			       bolEventStudentMapper,
			       dalEventStudentMapper,
			       bolEventTeacherMapper,
			       dalEventTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>88149ba6b842336388771535e0d922cd</Hash>
</Codenesium>*/