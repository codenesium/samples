using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IEventRepository eventRepository,
			IApiEventRequestModelValidator eventModelValidator,
			IBOLEventMapper boleventMapper,
			IDALEventMapper daleventMapper,
			IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
			IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper
			)
			: base(logger,
			       eventRepository,
			       eventModelValidator,
			       boleventMapper,
			       daleventMapper,
			       bolEventRelatedDocumentMapper,
			       dalEventRelatedDocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9d4ad3e4d6419d6d0ea36cf2c95a46ff</Hash>
</Codenesium>*/