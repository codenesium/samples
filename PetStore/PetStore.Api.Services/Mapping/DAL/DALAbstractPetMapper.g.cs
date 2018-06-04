using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALPetMapper
	{
		public virtual Pet MapBOToEF(
			BOPet bo)
		{
			Pet efPet = new Pet ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>53b1a1883b68374ce45d44ac38a0d9ab</Hash>
</Codenesium>*/