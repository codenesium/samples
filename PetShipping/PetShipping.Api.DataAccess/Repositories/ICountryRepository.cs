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

		Task<List<Country>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CountryRequirement>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<Destination>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9ad14b0e642f7bdb552e6a7263f69cc1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/