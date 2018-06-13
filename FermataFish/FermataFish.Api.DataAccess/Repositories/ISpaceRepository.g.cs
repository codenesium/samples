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

                Task<List<Space>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ef0c14acdf0261c253eb3ede9cb0d571</Hash>
</Codenesium>*/