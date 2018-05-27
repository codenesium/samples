using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALOtherTransportMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOOtherTransport dto,
			OtherTransport efOtherTransport)
		{
			efOtherTransport.SetProperties(
				id,
				dto.HandlerId,
				dto.PipelineStepId);
		}

		public virtual DTOOtherTransport MapEFToDTO(
			OtherTransport ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOOtherTransport();

			dto.SetProperties(
				ef.Id,
				ef.HandlerId,
				ef.PipelineStepId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>8e5756391d2883ddba48fadac0a34df5</Hash>
</Codenesium>*/