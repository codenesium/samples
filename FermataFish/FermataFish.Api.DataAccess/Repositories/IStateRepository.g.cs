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

                Task<List<State>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Studio>> Studios(int stateId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cfe49403d9603b1010cc12be7e6b3978</Hash>
</Codenesium>*/