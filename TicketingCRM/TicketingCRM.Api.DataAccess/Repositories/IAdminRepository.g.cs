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

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Venue>> Venues(int adminId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0e4cbfc090e6d27c4317f940403cb871</Hash>
</Codenesium>*/