using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IUsersRepository
	{
		Task<Users> Create(Users item);

		Task Update(Users item);

		Task Delete(int id);

		Task<Users> Get(int id);

		Task<List<Users>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5a523786a2e78f249563b3f37cae6faa</Hash>
</Codenesium>*/