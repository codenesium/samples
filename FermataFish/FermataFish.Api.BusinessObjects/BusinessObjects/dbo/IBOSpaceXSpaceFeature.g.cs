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
			SpaceXSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceXSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>525a002007967ef9b07df876cd754ad4</Hash>
</Codenesium>*/