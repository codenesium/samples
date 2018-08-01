using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStepRepository : AbstractPipelineStepRepository, IPipelineStepRepository
	{
		public PipelineStepRepository(
			ILogger<PipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>39a6748cb2f2dc2476fd2e47a162d7f9</Hash>
</Codenesium>*/