using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployeePayHistory
	{
		Task<CreateResponse<int>> Create(
			EmployeePayHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmployeePayHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmployeePayHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeePayHistory> GetWhereDirect(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d3e516d3bc6e9e1de2c919044b8cba1c</Hash>
</Codenesium>*/