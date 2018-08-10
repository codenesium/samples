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
    <Hash>8f3385dff10dca50195c26f365b25f83</Hash>
</Codenesium>*/