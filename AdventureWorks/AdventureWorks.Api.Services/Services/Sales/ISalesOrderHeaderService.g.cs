using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesOrderHeaderService
	{
		Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderHeaderRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiSalesOrderHeaderResponseModel> GetSalesOrderNumber(string salesOrderNumber);
		Task<List<ApiSalesOrderHeaderResponseModel>> GetCustomerID(int customerID);
		Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>d25fce37206a9decf10f464d9b684905</Hash>
</Codenesium>*/