using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALLinkMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLink dto,
			Link efLink)
		{
			efLink.SetProperties(
				id,
				dto.AssignedMachineId,
				dto.ChainId,
				dto.DateCompleted,
				dto.DateStarted,
				dto.DynamicParameters,
				dto.ExternalId,
				dto.LinkStatusId,
				dto.Name,
				dto.Order,
				dto.Response,
				dto.StaticParameters,
				dto.TimeoutInSeconds);
		}

		public virtual DTOLink MapEFToDTO(
			Link ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLink();

			dto.SetProperties(
				ef.Id,
				ef.AssignedMachineId,
				ef.ChainId,
				ef.DateCompleted,
				ef.DateStarted,
				ef.DynamicParameters,
				ef.ExternalId,
				ef.LinkStatusId,
				ef.Name,
				ef.Order,
				ef.Response,
				ef.StaticParameters,
				ef.TimeoutInSeconds);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>9e9f04caa0b7b9ba3ed474d0f363fa30</Hash>
</Codenesium>*/