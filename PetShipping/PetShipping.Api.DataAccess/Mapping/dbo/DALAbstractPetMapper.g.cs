using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
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
				dto.BreedId,
				dto.ClientId,
				dto.Name,
				dto.Weight);
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
				ef.BreedId,
				ef.ClientId,
				ef.Name,
				ef.Weight);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>25340c78fe2a890c9e63c4ed9232da2d</Hash>
</Codenesium>*/