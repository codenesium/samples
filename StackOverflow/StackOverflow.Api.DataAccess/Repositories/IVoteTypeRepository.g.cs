using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVoteTypeRepository
	{
		Task<VoteType> Create(VoteType item);

		Task Update(VoteType item);

		Task Delete(int id);

		Task<VoteType> Get(int id);

		Task<List<VoteType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Vote>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>29369f6973b3056051e29a6513601cfb</Hash>
</Codenesium>*/