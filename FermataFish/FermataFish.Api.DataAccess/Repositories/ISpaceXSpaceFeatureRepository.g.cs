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

                Task<List<SpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>dd2a4fb8f4ecb647dacbd1d5a68522cf</Hash>
</Codenesium>*/