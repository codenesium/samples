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

                Task<List<State>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Studio>> Studios(int stateId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8fc1679c382644b49a193e23079c370a</Hash>
</Codenesium>*/