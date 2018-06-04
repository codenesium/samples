using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>ddf08faa65844d9cbc093269a76faac8</Hash>
</Codenesium>*/