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
	}
}

/*<Codenesium>
    <Hash>d72649f45276818766cb9a3c539b795c</Hash>
</Codenesium>*/