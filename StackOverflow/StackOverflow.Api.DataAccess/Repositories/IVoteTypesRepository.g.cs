using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVoteTypesRepository
	{
		Task<VoteTypes> Create(VoteTypes item);

		Task Update(VoteTypes item);

		Task Delete(int id);

		Task<VoteTypes> Get(int id);

		Task<List<VoteTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>542b66cfc915369868abbda3683b8af1</Hash>
</Codenesium>*/