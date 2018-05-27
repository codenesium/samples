using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipeline dto,
			Pipeline efPipeline)
		{
			efPipeline.SetProperties(
				id,
				dto.PipelineStatusId,
				dto.SaleId);
		}

		public virtual DTOPipeline MapEFToDTO(
			Pipeline ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipeline();

			dto.SetProperties(
				ef.Id,
				ef.PipelineStatusId,
				ef.SaleId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e270d04f811512db5858e6e8aaee1b86</Hash>
</Codenesium>*/