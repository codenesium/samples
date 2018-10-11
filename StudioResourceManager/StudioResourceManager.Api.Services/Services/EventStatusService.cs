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
	public partial class EventStatusService : AbstractEventStatusService, IEventStatusService
	{
		public EventStatusService(
			ILogger<IEventStatusRepository> logger,
			IEventStatusRepository eventStatusRepository,
			IApiEventStatusRequestModelValidator eventStatusModelValidator,
			IBOLEventStatusMapper boleventStatusMapper,
			IDALEventStatusMapper daleventStatusMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       eventStatusRepository,
			       eventStatusModelValidator,
			       boleventStatusMapper,
			       daleventStatusMapper,
			       bolEventMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>099167a2d03e29082930d7576680d0fe</Hash>
</Codenesium>*/