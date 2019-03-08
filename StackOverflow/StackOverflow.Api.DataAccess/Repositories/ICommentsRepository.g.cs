using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ICommentsRepository
	{
		Task<Comments> Create(Comments item);

		Task Update(Comments item);

		Task Delete(int id);

		Task<Comments> Get(int id);

		Task<List<Comments>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Comments>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comments>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<Posts> PostsByPostId(int postId);

		Task<Users> UsersByUserId(int? userId);
	}
}

/*<Codenesium>
    <Hash>8922d3a22e52abe051a9eda5bb5cf027</Hash>
</Codenesium>*/