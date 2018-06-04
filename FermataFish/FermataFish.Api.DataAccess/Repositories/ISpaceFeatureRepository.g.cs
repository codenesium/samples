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
    <Hash>46bfa8d9f13197cde76d9688f8e369f0</Hash>
</Codenesium>*/