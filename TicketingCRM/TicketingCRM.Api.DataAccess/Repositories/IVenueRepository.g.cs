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

		Task<Admin> GetAdmin(int adminId);

		Task<Province> GetProvince(int provinceId);
	}
}

/*<Codenesium>
    <Hash>41f922379d657155bafd1557b7d05b56</Hash>
</Codenesium>*/