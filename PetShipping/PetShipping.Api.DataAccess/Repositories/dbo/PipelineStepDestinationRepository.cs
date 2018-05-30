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
	public class PipelineStepDestinationRepository: AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
	{
		public PipelineStepDestinationRepository(
			IDALPipelineStepDestinationMapper mapper,
			ILogger<PipelineStepDestinationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>54f9e11bd1f1868a6e659fc998c8a7d2</Hash>
</Codenesium>*/