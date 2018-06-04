using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		Task<State> Create(State item);

		Task Update(State item);

		Task Delete(int id);

		Task<State> Get(int id);

		Task<List<State>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2b12f955c8918d8ebf5bb8390b66eed2</Hash>
</Codenesium>*/