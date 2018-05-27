using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALCountryMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOCountry dto,
			Country efCountry)
		{
			efCountry.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOCountry MapEFToDTO(
			Country ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCountry();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>c365f655f5f11814c6718d73f296b50c</Hash>
</Codenesium>*/