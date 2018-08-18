using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(string id);

		Task<User> Get(string id);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0);

		Task<User> ByUsername(string username);

		Task<List<User>> ByDisplayName(string displayName, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> ByEmailAddress(string emailAddress, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> ByExternalId(string externalId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4245cd9b2881cd5c3bf5134431425b55</Hash>
</Codenesium>*/