using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStepMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStep dto,
			PipelineStep efPipelineStep)
		{
			efPipelineStep.SetProperties(
				id,
				dto.Name,
				dto.PipelineStepStatusId,
				dto.ShipperId);
		}

		public virtual DTOPipelineStep MapEFToDTO(
			PipelineStep ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStep();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.PipelineStepStatusId,
				ef.ShipperId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e5605b60239f9297a7a15888433319e9</Hash>
</Codenesium>*/