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

		Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0);

		Task<Country> GetCountry(int countryId);
	}
}

/*<Codenesium>
    <Hash>5cb28c7ec6c8c3657c38f29e557a8754</Hash>
</Codenesium>*/