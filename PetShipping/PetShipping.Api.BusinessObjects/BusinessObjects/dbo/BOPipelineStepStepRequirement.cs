using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOPipelineStepStepRequirement: AbstractBOPipelineStepStepRequirement, IBOPipelineStepStepRequirement
	{
		public BOPipelineStepStepRequirement(
			ILogger<PipelineStepStepRequirementRepository> logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper pipelineStepStepRequirementMapper)
			: base(logger, pipelineStepStepRequirementRepository, pipelineStepStepRequirementModelValidator, pipelineStepStepRequirementMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>57dd929ba6a0f3ae004a07d2827e0940</Hash>
</Codenesium>*/