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
    <Hash>c8a4006b9d48f1f5cd3dd121b70699cd</Hash>
</Codenesium>*/