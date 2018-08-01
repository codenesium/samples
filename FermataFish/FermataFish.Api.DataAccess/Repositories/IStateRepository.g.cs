using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
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
    <Hash>7ccd3c6b96f3bc735298d86824575dd4</Hash>
</Codenesium>*/