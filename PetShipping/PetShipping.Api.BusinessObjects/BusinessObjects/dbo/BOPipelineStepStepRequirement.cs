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
			IPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator)
			: base(logger, pipelineStepStepRequirementRepository, pipelineStepStepRequirementModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8cec8fc7c09c9b7f997a9c357782bef6</Hash>
</Codenesium>*/