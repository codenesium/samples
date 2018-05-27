using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeaderSalesReason
	{
		Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>40e92dfc313e34068a0278387f7cf816</Hash>
</Codenesium>*/