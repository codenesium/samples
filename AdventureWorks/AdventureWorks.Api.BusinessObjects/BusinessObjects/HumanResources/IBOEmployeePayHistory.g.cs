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

		Task<POCOEmployeePayHistory> Get(int businessEntityID);

		Task<List<POCOEmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>71b24343a541d7ca4f552d0ccd8f578c</Hash>
</Codenesium>*/