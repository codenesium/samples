using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>a2772e34addcf67d037ce3bf00a2ef92</Hash>
</Codenesium>*/