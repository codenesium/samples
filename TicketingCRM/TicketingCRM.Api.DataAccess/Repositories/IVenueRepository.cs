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

		Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Venue>> ByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<Admin> AdminByAdminId(int adminId);

		Task<Province> ProvinceByProvinceId(int provinceId);
	}
}

/*<Codenesium>
    <Hash>3339e028a8ccd8e9de57e9f005718280</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/