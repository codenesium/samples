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

		POCOEmployeePayHistory Get(int businessEntityID);

		List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>80b9cdfb964036b78503f6da82749195</Hash>
</Codenesium>*/