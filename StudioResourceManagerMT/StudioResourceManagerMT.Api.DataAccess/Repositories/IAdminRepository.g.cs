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

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Admin>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>ddf0783f103575edec657ee93f046fea</Hash>
</Codenesium>*/