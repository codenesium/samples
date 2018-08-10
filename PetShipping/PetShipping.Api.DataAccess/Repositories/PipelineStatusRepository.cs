using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStatusRepository : AbstractPipelineStatusRepository, IPipelineStatusRepository
	{
		public PipelineStatusRepository(
			ILogger<PipelineStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>01fed0396e1a6e78f9c8987740295486</Hash>
</Codenesium>*/