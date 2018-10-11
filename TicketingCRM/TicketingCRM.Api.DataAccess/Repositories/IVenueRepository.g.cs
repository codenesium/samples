using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface IVenueRepository
	{
		Task<Venue> Create(Venue item);

		Task Update(Venue item);

		Task Delete(int id);

		Task<Venue> Get(int id);

		Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> ByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<Admin> AdminByAdminId(int adminId);

		Task<Province> ProvinceByProvinceId(int provinceId);
	}
}

/*<Codenesium>
    <Hash>a862a14b0185a6b743e092c9cabb5710</Hash>
</Codenesium>*/