using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		int Create(SpaceModel model);

		void Update(int id,
		            SpaceModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOSpace GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpace> GetWhereDirect(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e3614e60056b7cfa17781d0ee31cb2e4</Hash>
</Codenesium>*/