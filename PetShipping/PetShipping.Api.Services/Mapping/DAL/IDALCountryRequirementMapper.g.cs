using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALCountryRequirementMapper
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
    <Hash>619e2d9237ecf65518be859e36b7cd71</Hash>
</Codenesium>*/