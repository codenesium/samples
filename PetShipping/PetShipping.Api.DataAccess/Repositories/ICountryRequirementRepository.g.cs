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

		Task<Country> CountryByCountryId(int countryId);
	}
}

/*<Codenesium>
    <Hash>b57c66eaa4acca383df7cb9b42e2c2a6</Hash>
</Codenesium>*/