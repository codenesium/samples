using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ISpaceRepository
	{
		Task<Space> Create(Space item);

		Task Update(Space item);

		Task Delete(int id);

		Task<Space> Get(int id);

		Task<List<Space>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>dedb871f57c74af8714c4e4e02d4b252</Hash>
</Codenesium>*/