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

                Task<List<SpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a8f870d39ee44bf021409113657c1bbe</Hash>
</Codenesium>*/