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
		Task<CreateResponse<POCOSpaceFeature>> Create(
			SpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d9e1df7ea35d6b289073bd5c86a59df1</Hash>
</Codenesium>*/