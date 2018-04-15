using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		int Create(StoreModel model);

		void Update(int businessEntityID,
		            StoreModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOStore GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStore> GetWhereDirect(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>624ddee250e4e473887c6ad2140e3424</Hash>
</Codenesium>*/