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

                Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int studioId);
        }
}

/*<Codenesium>
    <Hash>53c2c4b5ff9f0e818846a5fdf46a9af8</Hash>
</Codenesium>*/