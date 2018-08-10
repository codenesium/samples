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
    <Hash>7c209ec0acdeca3d01dccee7df89c886</Hash>
</Codenesium>*/