using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepDestinationRepository: AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
	{
		public PipelineStepDestinationRepository(
			ILogger<PipelineStepDestinationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b5d3f1bde061c15523de01d3efc72870</Hash>
</Codenesium>*/