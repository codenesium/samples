using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ICommentRepository
	{
		Task<Comment> Create(Comment item);

		Task Update(Comment item);

		Task Delete(int id);

		Task<Comment> Get(int id);

		Task<List<Comment>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Comment>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comment>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<Post> PostByPostId(int postId);

		Task<User> UserByUserId(int? userId);
	}
}

/*<Codenesium>
    <Hash>d6aa8c903b7d7fa696fecbd222258d54</Hash>
</Codenesium>*/