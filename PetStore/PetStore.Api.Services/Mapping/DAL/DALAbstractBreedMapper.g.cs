using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class DALAbstractBreedMapper
	{
		public virtual Breed MapBOToEF(
			BOBreed bo)
		{
			Breed efBreed = new Breed();
			efBreed.SetProperties(
				bo.Id,
				bo.Name);
			return efBreed;
		}

		public virtual BOBreed MapEFToBO(
			Breed ef)
		{
			var bo = new BOBreed();

			bo.SetProperties(
				ef.Id,
				ef.Name);
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
    <Hash>884c48b143957cb97075afec25878380</Hash>
</Codenesium>*/