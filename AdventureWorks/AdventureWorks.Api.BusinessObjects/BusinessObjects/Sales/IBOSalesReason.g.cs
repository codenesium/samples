using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesReason
	{
		Task<CreateResponse<int>> Create(
			SalesReasonModel model);

		Task<ActionResponse> Update(int salesReasonID,
		                            SalesReasonModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		ApiResponse GetById(int salesReasonID);

		POCOSalesReason GetByIdDirect(int salesReasonID);

		ApiResponse GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f31a0248453f4fdfa25a7a78182532d2</Hash>
</Codenesium>*/