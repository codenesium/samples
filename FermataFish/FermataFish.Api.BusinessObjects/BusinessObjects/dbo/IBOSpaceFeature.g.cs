using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpaceFeature
	{
		Task<CreateResponse<int>> Create(
			SpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f98dd6adaab5331adad0f7c8360bf907</Hash>
</Codenesium>*/