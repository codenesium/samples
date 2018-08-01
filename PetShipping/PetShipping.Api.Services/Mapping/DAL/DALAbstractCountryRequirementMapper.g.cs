using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractCountryRequirementMapper
	{
		public virtual CountryRequirement MapBOToEF(
			BOCountryRequirement bo)
		{
			CountryRequirement efCountryRequirement = new CountryRequirement();
			efCountryRequirement.SetProperties(
				bo.CountryId,
				bo.Details,
				bo.Id);
			return efCountryRequirement;
		}

		public virtual BOCountryRequirement MapEFToBO(
			CountryRequirement ef)
		{
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
    <Hash>afb6cbd43607de77b9e7f2b2ae994264</Hash>
</Codenesium>*/