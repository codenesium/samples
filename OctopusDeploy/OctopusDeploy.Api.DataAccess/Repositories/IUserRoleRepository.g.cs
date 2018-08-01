using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IUserRoleRepository
	{
		Task<UserRole> Create(UserRole item);

		Task Update(UserRole item);

		Task Delete(string id);

		Task<UserRole> Get(string id);

		Task<List<UserRole>> All(int limit = int.MaxValue, int offset = 0);

		Task<UserRole> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>37409d155475b80c75f3346655b5e8c5</Hash>
</Codenesium>*/