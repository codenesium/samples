using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALBreedMapper
	{
		public virtual Breed MapBOToEF(
			BOBreed bo)
		{
			Breed efBreed = new Breed ();

			efBreed.SetProperties(
				bo.Id,
				bo.Name,
				bo.SpeciesId);
			return efBreed;
		}

		public virtual BOBreed MapEFToBO(
			Breed ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOBreed();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.SpeciesId);
			return bo;
		}

		public virtual List<BOBreed> MapEFToBO(
			List<Breed> records)
		{
			List<BOBreed> response = new List<BOBreed>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e39207658516f22309199ddad77cd6b</Hash>
</Codenesium>*/