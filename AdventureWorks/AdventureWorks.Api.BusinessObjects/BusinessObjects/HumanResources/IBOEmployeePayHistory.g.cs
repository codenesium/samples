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
		Task<CreateResponse<POCOEmployeePayHistory>> Create(
			ApiEmployeePayHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmployeePayHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmployeePayHistory Get(int businessEntityID);

		List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2922883d4102f6c4a7da9ff2dfc59d92</Hash>
</Codenesium>*/