using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALStateMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOState dto,
			State efState)
		{
			efState.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOState MapEFToDTO(
			State ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOState();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>570a0f49dd97bdd48c2bd1dbcd45af30</Hash>
</Codenesium>*/