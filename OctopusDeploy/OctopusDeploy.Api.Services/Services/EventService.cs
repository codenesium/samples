using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>23d5c1924019f5667bff9c046e840dc2</Hash>
</Codenesium>*/