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
    <Hash>c9e4e13d9ff2fa4a7a06a7c2d74372b8</Hash>
</Codenesium>*/