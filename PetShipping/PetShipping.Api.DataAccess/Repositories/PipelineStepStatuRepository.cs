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
	public partial class PipelineStepStatuRepository : AbstractPipelineStepStatuRepository, IPipelineStepStatuRepository
	{
		public PipelineStepStatuRepository(
			ILogger<PipelineStepStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2b19644401b2119213a7219d88ec1428</Hash>
</Codenesium>*/