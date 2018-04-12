using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		int Create(
			string name,
			int studioId);

		void Update(int id,
		            string name,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOSpaceFeature GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c6e016220417a5dc76a878718f7636f9</Hash>
</Codenesium>*/