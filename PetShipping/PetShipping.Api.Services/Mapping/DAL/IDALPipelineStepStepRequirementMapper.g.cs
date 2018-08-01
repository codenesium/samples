using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>cb3dc9a5798127166dab82b763f35e4a</Hash>
</Codenesium>*/