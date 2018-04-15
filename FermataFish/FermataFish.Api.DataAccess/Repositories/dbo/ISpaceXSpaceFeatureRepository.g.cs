using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		int Create(SpaceXSpaceFeatureModel model);

		void Update(int id,
		            SpaceXSpaceFeatureModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOSpaceXSpaceFeature GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a68eda67bee4272d7075226c66056b1</Hash>
</Codenesium>*/