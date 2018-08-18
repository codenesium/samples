using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IAccountRepository
	{
		Task<Account> Create(Account item);

		Task Update(Account item);

		Task Delete(string id);

		Task<Account> Get(string id);

		Task<List<Account>> All(int limit = int.MaxValue, int offset = 0);

		Task<Account> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>2438a42efa1bf221cbbab99d892f3b84</Hash>
</Codenesium>*/