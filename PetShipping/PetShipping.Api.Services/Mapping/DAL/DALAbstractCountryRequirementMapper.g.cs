using Microsoft.EntityFrameworkCore;
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
				bo.Detail,
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
				ef.Detail);
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
    <Hash>14555c6c538a3adee359dafc5d591337</Hash>
</Codenesium>*/