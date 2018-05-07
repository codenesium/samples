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
			IObjectMapper mapper,
			ILogger<PipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>185b3f48ce7e1a8fa76f450c22b18a24</Hash>
</Codenesium>*/