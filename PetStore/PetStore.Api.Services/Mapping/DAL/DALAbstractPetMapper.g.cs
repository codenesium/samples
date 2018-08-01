using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class DALAbstractPetMapper
	{
		public virtual Pet MapBOToEF(
			BOPet bo)
		{
			Pet efPet = new Pet();
			efPet.SetProperties(
				bo.AcquiredDate,
				bo.BreedId,
				bo.Description,
				bo.Id,
				bo.PenId,
				bo.Price,
				bo.SpeciesId);
			return efPet;
		}

		public virtual BOPet MapEFToBO(
			Pet ef)
		{
			var bo = new BOPet();

			bo.SetProperties(
				ef.Id,
				ef.AcquiredDate,
				ef.BreedId,
				ef.Description,
				ef.PenId,
				ef.Price,
				ef.SpeciesId);
			return bo;
		}

		public virtual List<BOPet> MapEFToBO(
			List<Pet> records)
		{
			List<BOPet> response = new List<BOPet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a859894c2c8462bd0b1115bf25aacfc6</Hash>
</Codenesium>*/