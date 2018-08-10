using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IStateRepository
	{
		Task<State> Create(State item);

		Task Update(State item);

		Task Delete(int id);

		Task<State> Get(int id);

		Task<List<State>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Studio>> Studios(int stateId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ec7c374b9ffe6ba1fcdc26db57278efd</Hash>
</Codenesium>*/