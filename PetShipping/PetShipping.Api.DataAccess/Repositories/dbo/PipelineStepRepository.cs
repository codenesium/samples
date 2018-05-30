using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepRepository: AbstractPipelineStepRepository, IPipelineStepRepository
	{
		public PipelineStepRepository(
			IDALPipelineStepMapper mapper,
			ILogger<PipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>39c5cd4fceafafa929e2f83c8a57cce5</Hash>
</Codenesium>*/