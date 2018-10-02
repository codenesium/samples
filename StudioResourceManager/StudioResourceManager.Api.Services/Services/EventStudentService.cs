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
	public partial class EventStudentService : AbstractEventStudentService, IEventStudentService
	{
		public EventStudentService(
			ILogger<IEventStudentRepository> logger,
			IEventStudentRepository eventStudentRepository,
			IApiEventStudentRequestModelValidator eventStudentModelValidator,
			IBOLEventStudentMapper boleventStudentMapper,
			IDALEventStudentMapper daleventStudentMapper
			)
			: base(logger,
			       eventStudentRepository,
			       eventStudentModelValidator,
			       boleventStudentMapper,
			       daleventStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b4b7bc23b33340ea45e791bf2ec5bd8d</Hash>
</Codenesium>*/