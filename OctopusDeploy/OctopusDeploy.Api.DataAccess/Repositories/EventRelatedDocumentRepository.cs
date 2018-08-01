using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class EventRelatedDocumentRepository : AbstractEventRelatedDocumentRepository, IEventRelatedDocumentRepository
	{
		public EventRelatedDocumentRepository(
			ILogger<EventRelatedDocumentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>873f493ff1069b1f408511c100a4f363</Hash>
</Codenesium>*/