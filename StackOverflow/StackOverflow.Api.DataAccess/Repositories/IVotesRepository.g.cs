using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVotesRepository
	{
		Task<Votes> Create(Votes item);

		Task Update(Votes item);

		Task Delete(int id);

		Task<Votes> Get(int id);

		Task<List<Votes>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Votes>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Votes>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Votes>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);

		Task<Posts> PostsByPostId(int postId);

		Task<Users> UsersByUserId(int? userId);

		Task<VoteTypes> VoteTypesByVoteTypeId(int voteTypeId);
	}
}

/*<Codenesium>
    <Hash>eb4179c2e2429f6c9da7d716833d0030</Hash>
</Codenesium>*/