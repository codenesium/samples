using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IAccountRepository
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
    <Hash>c1da8943ee3e231c44bf89ea8abff623</Hash>
</Codenesium>*/