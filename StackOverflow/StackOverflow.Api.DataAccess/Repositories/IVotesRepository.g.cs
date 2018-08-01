using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IVotesRepository
	{
		Task<Votes> Create(Votes item);

		Task Update(Votes item);

		Task Delete(int id);

		Task<Votes> Get(int id);

		Task<List<Votes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1b456ee36d92e0f1c85626cc4203f6e3</Hash>
</Codenesium>*/