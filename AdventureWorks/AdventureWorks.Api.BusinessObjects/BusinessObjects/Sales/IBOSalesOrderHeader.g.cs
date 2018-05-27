using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeader
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
    <Hash>728176dc6335583e14b9c8c66b1172b2</Hash>
</Codenesium>*/