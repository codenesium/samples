using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>31b18d798d50b7bc7cacc59e05aa78c0</Hash>
</Codenesium>*/