using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ICountryRequirementRepository
	{
		Task<CountryRequirement> Create(CountryRequirement item);

		Task Update(CountryRequirement item);

		Task Delete(int id);

		Task<CountryRequirement> Get(int id);

		Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Country> CountryByCountryId(int countryId);
	}
}

/*<Codenesium>
    <Hash>aa2f89e131ae34a534e1f70ff518f2f8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/