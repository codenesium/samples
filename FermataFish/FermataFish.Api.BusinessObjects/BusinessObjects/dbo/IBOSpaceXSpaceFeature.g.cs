using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpaceXSpaceFeature
	{
		Task<CreateResponse<int>> Create(
			SpaceXSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceXSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7417f17f66eda76e52087ffabdfa9d2c</Hash>
</Codenesium>*/