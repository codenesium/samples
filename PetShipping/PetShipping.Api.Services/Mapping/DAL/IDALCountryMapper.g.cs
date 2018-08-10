using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCountryMapper
	{
		Country MapBOToEF(
			BOCountry bo);

		BOCountry MapEFToBO(
			Country efCountry);

		List<BOCountry> MapEFToBO(
			List<Country> records);
	}
}

/*<Codenesium>
    <Hash>df98422a8a23cd1ad6c7e28241417c1c</Hash>
</Codenesium>*/