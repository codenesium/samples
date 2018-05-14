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
		Task<CreateResponse<POCOSpaceXSpaceFeature>> Create(
			ApiSpaceXSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceXSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>333777813af8e94e898585f8a0012fb0</Hash>
</Codenesium>*/