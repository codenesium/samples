using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public interface IVenueRepository
	{
		Task<Venue> Create(Venue item);

		Task Update(Venue item);

		Task Delete(int id);

		Task<Venue> Get(int id);

		Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> ByAdminId(int adminId);

		Task<List<Venue>> ByProvinceId(int provinceId);

		Task<Admin> GetAdmin(int adminId);

		Task<Province> GetProvince(int provinceId);
	}
}

/*<Codenesium>
    <Hash>1b1400423e07d97ddf76895adb4ae1a4</Hash>
</Codenesium>*/