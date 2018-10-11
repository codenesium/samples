using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ISpaceRepository
	{
		Task<Space> Create(Space item);

		Task Update(Space item);

		Task Delete(int id);

		Task<Space> Get(int id);

		Task<List<Space>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>862d47c575b9f8186b3e145b712264fe</Hash>
</Codenesium>*/