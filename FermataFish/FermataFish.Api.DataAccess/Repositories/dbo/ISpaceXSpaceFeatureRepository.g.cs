using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		int Create(
			int spaceId,
			int spaceFeatureId);

		void Update(int id,
		            int spaceId,
		            int spaceFeatureId);

		void Delete(int id);

		Response GetById(int id);

		POCOSpaceXSpaceFeature GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7d2146edfa87a6c9f36c5780efae5fed</Hash>
</Codenesium>*/