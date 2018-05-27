using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractDALSpeciesMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOSpecies dto,
			Species efSpecies)
		{
			efSpecies.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOSpecies MapEFToDTO(
			Species ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpecies();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1f5c7b945f9e7198969d44b860dbd9d5</Hash>
</Codenesium>*/