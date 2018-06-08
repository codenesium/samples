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
    <Hash>97b1d978cc7189eebec7649818e77e83</Hash>
</Codenesium>*/