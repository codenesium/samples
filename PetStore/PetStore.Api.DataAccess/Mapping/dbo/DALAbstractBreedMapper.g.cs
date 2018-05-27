using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
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
				dto.Name);
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
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>3fe57ccf84680cecd06341dfd4340d93</Hash>
</Codenesium>*/