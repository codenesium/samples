using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ICountryRepository
	{
		Task<Country> Create(Country item);

		Task Update(Country item);

		Task Delete(int id);

		Task<Country> Get(int id);

		Task<List<Country>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<CountryRequirement>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<Destination>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a9d2a71f506af4f7f652a34aa613bc90</Hash>
</Codenesium>*/