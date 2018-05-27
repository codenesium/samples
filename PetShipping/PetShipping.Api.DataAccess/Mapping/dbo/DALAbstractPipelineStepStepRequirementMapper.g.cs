using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStepStepRequirementMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStepStepRequirement dto,
			PipelineStepStepRequirement efPipelineStepStepRequirement)
		{
			efPipelineStepStepRequirement.SetProperties(
				id,
				dto.Details,
				dto.PipelineStepId,
				dto.RequirementMet);
		}

		public virtual DTOPipelineStepStepRequirement MapEFToDTO(
			PipelineStepStepRequirement ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStepStepRequirement();

			dto.SetProperties(
				ef.Id,
				ef.Details,
				ef.PipelineStepId,
				ef.RequirementMet);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>34fc93090245459aed7cd8b285652de7</Hash>
</Codenesium>*/