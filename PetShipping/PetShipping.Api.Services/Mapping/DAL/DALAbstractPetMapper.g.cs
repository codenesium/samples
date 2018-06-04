using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPetMapper
	{
		public virtual Pet MapBOToEF(
			BOPet bo)
		{
			Pet efPet = new Pet ();

			efPet.SetProperties(
				bo.BreedId,
				bo.ClientId,
				bo.Id,
				bo.Name,
				bo.Weight);
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
				ef.BreedId,
				ef.ClientId,
				ef.Name,
				ef.Weight);
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
    <Hash>223551ad8612c9e731c74e34b0d7c3dc</Hash>
</Codenesium>*/