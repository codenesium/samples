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
    <Hash>48125a9bd18bfbaf6d4b574d1ad222c9</Hash>
</Codenesium>*/