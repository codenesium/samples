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
			ApiSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a07c672fc95aa09fd6b57469f4674d6</Hash>
</Codenesium>*/