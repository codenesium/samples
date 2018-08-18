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
	public partial class EventRelatedDocumentService : AbstractEventRelatedDocumentService, IEventRelatedDocumentService
	{
		public EventRelatedDocumentService(
			ILogger<IEventRelatedDocumentRepository> logger,
			IEventRelatedDocumentRepository eventRelatedDocumentRepository,
			IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator,
			IBOLEventRelatedDocumentMapper boleventRelatedDocumentMapper,
			IDALEventRelatedDocumentMapper daleventRelatedDocumentMapper
			)
			: base(logger,
			       eventRelatedDocumentRepository,
			       eventRelatedDocumentModelValidator,
			       boleventRelatedDocumentMapper,
			       daleventRelatedDocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>21ea50561693e07d6f0f8eaef3385f48</Hash>
</Codenesium>*/