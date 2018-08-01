using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public interface ICityRepository
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
    <Hash>12d4bb6984db3c8ec00cd91496dc101b</Hash>
</Codenesium>*/