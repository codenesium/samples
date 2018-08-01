using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPetMapper
	{
		public virtual Pet MapBOToEF(
			BOPet bo)
		{
			Pet efPet = new Pet();
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
    <Hash>ca919994882250dd1fabf6a07a5fe48e</Hash>
</Codenesium>*/