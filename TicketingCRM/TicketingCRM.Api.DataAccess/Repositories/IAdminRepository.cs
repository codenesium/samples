using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface IAdminRepository
	{
		Task<Admin> Create(Admin item);

		Task Update(Admin item);

		Task Delete(int id);

		Task<Admin> Get(int id);

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Venue>> VenuesByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eeea0c55e596be496b4b6e54c0795259</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/