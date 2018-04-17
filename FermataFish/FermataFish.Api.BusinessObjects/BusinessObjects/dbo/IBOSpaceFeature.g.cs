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

		ApiResponse GetById(int id);

		POCOSpaceFeature GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d328cc17f6b4eff4167bee615cada8b</Hash>
</Codenesium>*/