using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostsRepository
	{
		Task<Posts> Create(Posts item);

		Task Update(Posts item);

		Task Delete(int id);

		Task<Posts> Get(int id);

		Task<List<Posts>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1f32e3e0ced8b93aebfafbae2a6f036c</Hash>
</Codenesium>*/