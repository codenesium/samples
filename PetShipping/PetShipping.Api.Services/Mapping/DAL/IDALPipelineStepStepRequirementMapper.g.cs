using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStepStepRequirementMapper
	{
		PipelineStepStepRequirement MapBOToEF(
			BOPipelineStepStepRequirement bo);

		BOPipelineStepStepRequirement MapEFToBO(
			PipelineStepStepRequirement efPipelineStepStepRequirement);

		List<BOPipelineStepStepRequirement> MapEFToBO(
			List<PipelineStepStepRequirement> records);
	}
}

/*<Codenesium>
    <Hash>7705a519bd0cf6f1f27b0a994f16748b</Hash>
</Codenesium>*/