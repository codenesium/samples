using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALCountryMapper
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
    <Hash>6c5a56d113148a1c5250900f1180d27c</Hash>
</Codenesium>*/