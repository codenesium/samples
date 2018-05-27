using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALSpaceMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOSpace dto,
			Space efSpace)
		{
			efSpace.SetProperties(
				id,
				dto.Description,
				dto.Name,
				dto.StudioId);
		}

		public virtual DTOSpace MapEFToDTO(
			Space ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpace();

			dto.SetProperties(
				ef.Id,
				ef.Description,
				ef.Name,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>15ae96d6cbcdf8e6b149d0834b527d1f</Hash>
</Codenesium>*/