using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
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
    <Hash>7c8a83bfe07d93b5fd13fed15aa3ba49</Hash>
</Codenesium>*/