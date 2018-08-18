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
    <Hash>a59a13459d78ae0a1670bf9815ec01a6</Hash>
</Codenesium>*/