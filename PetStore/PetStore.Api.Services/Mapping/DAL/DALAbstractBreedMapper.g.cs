using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALBreedMapper
	{
		public virtual Breed MapBOToEF(
			BOBreed bo)
		{
			Breed efBreed = new Breed ();

			efBreed.SetProperties(
				bo.Id,
				bo.Name);
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
    <Hash>4610eb90915f40f2e44a53ebf9aed59c</Hash>
</Codenesium>*/