using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ISpaceXSpaceFeatureRepository
        {
                Task<SpaceXSpaceFeature> Create(SpaceXSpaceFeature item);

                Task Update(SpaceXSpaceFeature item);

                Task Delete(int id);

                Task<SpaceXSpaceFeature> Get(int id);

                Task<List<SpaceXSpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

                Task<SpaceFeature> GetSpaceFeature(int spaceFeatureId);

                Task<Space> GetSpace(int spaceId);
        }
}

/*<Codenesium>
    <Hash>1953c2ca02fd9d1322eae46904d4b7c9</Hash>
</Codenesium>*/