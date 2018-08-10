using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStepRequirementMapper
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
    <Hash>9f28037a769e400b0542e71401776526</Hash>
</Codenesium>*/