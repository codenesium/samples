using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		Task<POCOCountry> Create(ApiCountryModel model);

		Task Update(int id,
		            ApiCountryModel model);

		Task Delete(int id);

		Task<POCOCountry> Get(int id);

		Task<List<POCOCountry>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>320730561eb90ef35e39489de0fdd8a5</Hash>
</Codenesium>*/