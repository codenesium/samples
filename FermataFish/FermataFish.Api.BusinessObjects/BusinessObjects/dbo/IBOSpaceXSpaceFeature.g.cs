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

		ApiResponse GetById(int id);

		POCOSpaceXSpaceFeature GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bb143a7f3b86ced063b66ac9f84c07a1</Hash>
</Codenesium>*/