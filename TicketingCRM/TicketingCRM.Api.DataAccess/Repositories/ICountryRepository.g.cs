using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ICountryRepository
	{
		Task<Country> Create(Country item);

		Task Update(Country item);

		Task Delete(int id);

		Task<Country> Get(int id);

		Task<List<Country>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Province>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9975c14d4295a3a7cce81b62ab334ec0</Hash>
</Codenesium>*/