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
    <Hash>246022fe7a4cefd386662533ed59e1ff</Hash>
</Codenesium>*/