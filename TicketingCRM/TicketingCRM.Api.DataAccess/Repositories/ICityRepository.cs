using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ICityRepository
	{
		Task<City> Create(City item);

		Task Update(City item);

		Task Delete(int id);

		Task<City> Get(int id);

		Task<List<City>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<City>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0);

		Task<Province> ProvinceByProvinceId(int provinceId);
	}
}

/*<Codenesium>
    <Hash>2b02af1d094c1a21905a449039f2ff1f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/