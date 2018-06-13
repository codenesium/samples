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

                Task<List<SpaceXSpaceFeature>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>de462b1f7941c8c794248be727c57d56</Hash>
</Codenesium>*/