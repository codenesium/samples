using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		int Create(SalesPersonModel model);

		void Update(int businessEntityID,
		            SalesPersonModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesPerson GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e770c9f79b0f9838b3ee5df2f450178b</Hash>
</Codenesium>*/