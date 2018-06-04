using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALCountryRequirementMapper
	{
		public virtual CountryRequirement MapBOToEF(
			BOCountryRequirement bo)
		{
			CountryRequirement efCountryRequirement = new CountryRequirement ();

			efCountryRequirement.SetProperties(
				bo.CountryId,
				bo.Details,
				bo.Id);
			return efCountryRequirement;
		}

		public virtual BOCountryRequirement MapEFToBO(
			CountryRequirement ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOCountryRequirement();

			bo.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Details);
			return bo;
		}

		public virtual List<BOCountryRequirement> MapEFToBO(
			List<CountryRequirement> records)
		{
			List<BOCountryRequirement> response = new List<BOCountryRequirement>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>34fe512817ec8fc3c549a6d01c2b97a4</Hash>
</Codenesium>*/