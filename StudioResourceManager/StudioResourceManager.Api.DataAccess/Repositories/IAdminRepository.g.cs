using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IAdminRepository
	{
		Task<Admin> Create(Admin item);

		Task Update(Admin item);

		Task Delete(int id);

		Task<Admin> Get(int id);

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>7eed177aa646d82cb38aa3560446d8db</Hash>
</Codenesium>*/