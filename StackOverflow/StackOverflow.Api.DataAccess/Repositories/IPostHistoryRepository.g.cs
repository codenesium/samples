using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryRepository
	{
		Task<PostHistory> Create(PostHistory item);

		Task Update(PostHistory item);

		Task Delete(int id);

		Task<PostHistory> Get(int id);

		Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostHistory>> ByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<PostHistoryTypes> PostHistoryTypesByPostHistoryTypeId(int postHistoryTypeId);

		Task<Posts> PostsByPostId(int postId);

		Task<Users> UsersByUserId(int? userId);
	}
}

/*<Codenesium>
    <Hash>6d416dc5bf88d5ff5892d0d5529c5caf</Hash>
</Codenesium>*/