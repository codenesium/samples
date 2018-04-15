using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		int Create(SpaceFeatureModel model);

		void Update(int id,
		            SpaceFeatureModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOSpaceFeature GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27fe6bf41914ba0c26776546cba8f271</Hash>
</Codenesium>*/