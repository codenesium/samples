using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractDALPetMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPet dto,
			Pet efPet)
		{
			efPet.SetProperties(
				id,
				dto.AcquiredDate,
				dto.BreedId,
				dto.Description,
				dto.PenId,
				dto.Price,
				dto.SpeciesId);
		}

		public virtual DTOPet MapEFToDTO(
			Pet ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPet();

			dto.SetProperties(
				ef.Id,
				ef.AcquiredDate,
				ef.BreedId,
				ef.Description,
				ef.PenId,
				ef.Price,
				ef.SpeciesId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b81a2f27590ecabdd072763424de0a65</Hash>
</Codenesium>*/