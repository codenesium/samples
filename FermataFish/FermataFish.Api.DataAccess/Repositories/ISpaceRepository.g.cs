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

                Task<List<Space>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int studioId);
        }
}

/*<Codenesium>
    <Hash>f53cc02efb01f793fa45e71a07a97739</Hash>
</Codenesium>*/