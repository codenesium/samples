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

		Task<List<VoteType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c02c16b4b9e3364c28e831f5bd00c0ae</Hash>
</Codenesium>*/