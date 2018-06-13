using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ISpaceFeatureRepository
        {
                Task<SpaceFeature> Create(SpaceFeature item);

                Task Update(SpaceFeature item);

                Task Delete(int id);

                Task<SpaceFeature> Get(int id);

                Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7bdfbe2e2424930b349c7fe564b2a56f</Hash>
</Codenesium>*/