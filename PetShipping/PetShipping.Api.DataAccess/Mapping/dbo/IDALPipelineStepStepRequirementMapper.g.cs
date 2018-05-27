using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStepStepRequirementMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStepStepRequirement dto,
			PipelineStepStepRequirement efPipelineStepStepRequirement);

		DTOPipelineStepStepRequirement MapEFToDTO(
			PipelineStepStepRequirement efPipelineStepStepRequirement);
	}
}

/*<Codenesium>
    <Hash>9489d8a780e7563bf7aeef814af06a17</Hash>
</Codenesium>*/