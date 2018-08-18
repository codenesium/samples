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

		Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<Country> GetCountry(int countryId);
	}
}

/*<Codenesium>
    <Hash>8986cdb051d3feabc3e8c951b7ef2771</Hash>
</Codenesium>*/