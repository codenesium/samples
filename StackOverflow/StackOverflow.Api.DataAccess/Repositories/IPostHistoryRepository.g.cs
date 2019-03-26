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

		Task<PostHistoryType> PostHistoryTypeByPostHistoryTypeId(int postHistoryTypeId);

		Task<Post> PostByPostId(int postId);

		Task<User> UserByUserId(int? userId);
	}
}

/*<Codenesium>
    <Hash>71ef042709d9215802ccf12eb2aee925</Hash>
</Codenesium>*/