using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALBreedMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOBreed dto,
			Breed efBreed)
		{
			efBreed.SetProperties(
				id,
				dto.Name,
				dto.SpeciesId);
		}

		public virtual DTOBreed MapEFToDTO(
			Breed ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBreed();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.SpeciesId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b6d5d679112588992b2a4a9538ccb252</Hash>
</Codenesium>*/