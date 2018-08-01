using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IPostsRepository
	{
		Task<Posts> Create(Posts item);

		Task Update(Posts item);

		Task Delete(int id);

		Task<Posts> Get(int id);

		Task<List<Posts>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>50e317a84ebb904f6cbe952c5cb542bf</Hash>
</Codenesium>*/