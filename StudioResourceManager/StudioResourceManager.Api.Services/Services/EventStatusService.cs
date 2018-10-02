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
			IDALEventStatusMapper daleventStatusMapper
			)
			: base(logger,
			       eventStatusRepository,
			       eventStatusModelValidator,
			       boleventStatusMapper,
			       daleventStatusMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f4764f50187cffcd3d7f50e359e1e5c1</Hash>
</Codenesium>*/