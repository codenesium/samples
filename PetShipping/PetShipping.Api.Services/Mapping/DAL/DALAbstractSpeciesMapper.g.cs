using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractSpeciesMapper
	{
		public virtual Species MapBOToEF(
			BOSpecies bo)
		{
			Species efSpecies = new Species();
			efSpecies.SetProperties(
				bo.Id,
				bo.Name);
			return efSpecies;
		}

		public virtual BOSpecies MapEFToBO(
			Species ef)
		{
			var bo = new BOSpecies();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOSpecies> MapEFToBO(
			List<Species> records)
		{
			List<BOSpecies> response = new List<BOSpecies>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b37555fc776fb3aa342e571c829cf0e2</Hash>
</Codenesium>*/