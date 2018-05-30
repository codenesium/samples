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
	public class PipelineStepStatusRepository: AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
	{
		public PipelineStepStatusRepository(
			IDALPipelineStepStatusMapper mapper,
			ILogger<PipelineStepStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>04bf89a6cc1f5eb163524c65ca877030</Hash>
</Codenesium>*/