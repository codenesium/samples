using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepStepRequirementRepository: AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
	{
		public PipelineStepStepRequirementRepository(
			ILogger<PipelineStepStepRequirementRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>97e6aaa88a3144aabf2c69b452387fc6</Hash>
</Codenesium>*/