using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStatusMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStatus dto,
			PipelineStatus efPipelineStatus)
		{
			efPipelineStatus.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOPipelineStatus MapEFToDTO(
			PipelineStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStatus();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>d4b02e334b0f78184e2aa26beb1c1c51</Hash>
</Codenesium>*/