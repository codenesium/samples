using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVoteRepository
	{
		Task<Vote> Create(Vote item);

		Task Update(Vote item);

		Task Delete(int id);

		Task<Vote> Get(int id);

		Task<List<Vote>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Vote>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vote>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vote>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);

		Task<Post> PostByPostId(int postId);

		Task<User> UserByUserId(int? userId);

		Task<VoteType> VoteTypeByVoteTypeId(int voteTypeId);
	}
}

/*<Codenesium>
    <Hash>7b69e3b193bf87b4643d8d0002dc0ef0</Hash>
</Codenesium>*/