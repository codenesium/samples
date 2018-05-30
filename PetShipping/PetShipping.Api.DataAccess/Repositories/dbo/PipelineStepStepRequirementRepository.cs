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
	public class PipelineStepStepRequirementRepository: AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
	{
		public PipelineStepStepRequirementRepository(
			IDALPipelineStepStepRequirementMapper mapper,
			ILogger<PipelineStepStepRequirementRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>91fcd0798bb98ce1643f0865542bbc39</Hash>
</Codenesium>*/