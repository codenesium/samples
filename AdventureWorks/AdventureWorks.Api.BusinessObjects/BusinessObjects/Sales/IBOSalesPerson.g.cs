using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPerson
	{
		Task<CreateResponse<int>> Create(
			SalesPersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesPersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesPerson GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1f82ebd3fa4836c8254d28ef43e4be40</Hash>
</Codenesium>*/