using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesOrderDetailService
	{
		Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
			ApiSalesOrderDetailRequestModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderDetailRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiSalesOrderDetailResponseModel>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>90bb730b5bfd22f873486c966cea626b</Hash>
</Codenesium>*/