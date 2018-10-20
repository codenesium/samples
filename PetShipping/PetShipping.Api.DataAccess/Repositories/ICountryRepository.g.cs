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

		Task<List<CountryRequirement>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<Destination>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>969b289b6fb83d4e00366ae7326bbb18</Hash>
</Codenesium>*/