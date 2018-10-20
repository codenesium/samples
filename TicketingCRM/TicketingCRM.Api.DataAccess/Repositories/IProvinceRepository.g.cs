using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface IProvinceRepository
	{
		Task<Province> Create(Province item);

		Task Update(Province item);

		Task Delete(int id);

		Task<Province> Get(int id);

		Task<List<Province>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Province>> ByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<City>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<Country> CountryByCountryId(int countryId);
	}
}

/*<Codenesium>
    <Hash>cc86cefc60371f1b333d6ef68c784b68</Hash>
</Codenesium>*/