using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IVoteTypesRepository
	{
		Task<VoteTypes> Create(VoteTypes item);

		Task Update(VoteTypes item);

		Task Delete(int id);

		Task<VoteTypes> Get(int id);

		Task<List<VoteTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e51e0c7da2fbda87b333ed6c382855c5</Hash>
</Codenesium>*/