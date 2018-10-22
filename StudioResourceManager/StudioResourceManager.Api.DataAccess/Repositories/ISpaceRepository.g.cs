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

		Task<List<Space>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b4589b81d49ca56182d64a89541ef314</Hash>
</Codenesium>*/