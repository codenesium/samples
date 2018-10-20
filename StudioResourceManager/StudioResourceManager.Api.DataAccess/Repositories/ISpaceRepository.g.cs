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

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesBySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5465e6bd639cde0eca98c42e6f6a61b7</Hash>
</Codenesium>*/