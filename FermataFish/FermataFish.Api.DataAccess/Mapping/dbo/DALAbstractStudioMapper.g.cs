using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALStudioMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOStudio dto,
			Studio efStudio)
		{
			efStudio.SetProperties(
				id,
				dto.Address1,
				dto.Address2,
				dto.City,
				dto.Name,
				dto.StateId,
				dto.Website,
				dto.Zip);
		}

		public virtual DTOStudio MapEFToDTO(
			Studio ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOStudio();

			dto.SetProperties(
				ef.Id,
				ef.Address1,
				ef.Address2,
				ef.City,
				ef.Name,
				ef.StateId,
				ef.Website,
				ef.Zip);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b298cdd60eda97c98910e747b78e4002</Hash>
</Codenesium>*/