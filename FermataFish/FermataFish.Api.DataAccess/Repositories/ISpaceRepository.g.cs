using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ISpaceRepository
        {
                Task<Space> Create(Space item);

                Task Update(Space item);

                Task Delete(int id);

                Task<Space> Get(int id);

                Task<List<Space>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>deb24c5bab2c72d5fc79ad1758025462</Hash>
</Codenesium>*/