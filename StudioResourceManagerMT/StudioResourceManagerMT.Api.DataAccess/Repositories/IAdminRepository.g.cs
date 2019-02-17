using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IAdminRepository
	{
		Task<Admin> Create(Admin item);

		Task Update(Admin item);

		Task Delete(int id);

		Task<Admin> Get(int id);

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Admin>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>99f0e323f1bf2d7fd97255d40b71dc50</Hash>
</Codenesium>*/