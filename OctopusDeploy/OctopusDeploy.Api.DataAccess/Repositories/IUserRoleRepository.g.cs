using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IUserRoleRepository
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
    <Hash>ae3a54467765d83d792532aa62ce8e4a</Hash>
</Codenesium>*/