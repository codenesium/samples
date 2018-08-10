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

		Task<List<City>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<City>> ByProvinceId(int provinceId);

		Task<List<Event>> Events(int cityId, int limit = int.MaxValue, int offset = 0);

		Task<Province> GetProvince(int provinceId);
	}
}

/*<Codenesium>
    <Hash>641e00990019946a7016945ddbb0ed96</Hash>
</Codenesium>*/