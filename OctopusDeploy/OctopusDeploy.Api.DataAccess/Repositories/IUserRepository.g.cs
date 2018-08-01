using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(string id);

		Task<User> Get(string id);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0);

		Task<User> ByUsername(string username);

		Task<List<User>> ByDisplayName(string displayName);

		Task<List<User>> ByEmailAddress(string emailAddress);

		Task<List<User>> ByExternalId(string externalId);
	}
}

/*<Codenesium>
    <Hash>0b1c3badf95cd45c75472bd2289919c8</Hash>
</Codenesium>*/