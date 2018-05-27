using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStepDestinationMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStepDestination dto,
			PipelineStepDestination efPipelineStepDestination)
		{
			efPipelineStepDestination.SetProperties(
				id,
				dto.DestinationId,
				dto.PipelineStepId);
		}

		public virtual DTOPipelineStepDestination MapEFToDTO(
			PipelineStepDestination ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStepDestination();

			dto.SetProperties(
				ef.Id,
				ef.DestinationId,
				ef.PipelineStepId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ee68faa1ebb294bf98f0380e48e5e3d1</Hash>
</Codenesium>*/