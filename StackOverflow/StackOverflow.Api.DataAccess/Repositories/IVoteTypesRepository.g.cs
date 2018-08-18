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
    <Hash>f68fb94554c5ff39bb3fb8b203119c2c</Hash>
</Codenesium>*/