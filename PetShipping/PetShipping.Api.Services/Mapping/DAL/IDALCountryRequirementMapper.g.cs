using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCountryRequirementMapper
	{
		CountryRequirement MapBOToEF(
			BOCountryRequirement bo);

		BOCountryRequirement MapEFToBO(
			CountryRequirement efCountryRequirement);

		List<BOCountryRequirement> MapEFToBO(
			List<CountryRequirement> records);
	}
}

/*<Codenesium>
    <Hash>c98c871c0bbb23ed3ec65bab9ec93999</Hash>
</Codenesium>*/