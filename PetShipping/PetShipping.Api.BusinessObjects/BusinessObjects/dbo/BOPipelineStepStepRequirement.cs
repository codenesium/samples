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
			IApiPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator)
			: base(logger, pipelineStepStepRequirementRepository, pipelineStepStepRequirementModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4813af51197515a4e0e0ad618e2ed897</Hash>
</Codenesium>*/