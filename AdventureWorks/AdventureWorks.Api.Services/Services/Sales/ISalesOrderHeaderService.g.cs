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

                Task<List<ApiSalesOrderHeaderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiSalesOrderHeaderResponseModel> BySalesOrderNumber(string salesOrderNumber);
                Task<List<ApiSalesOrderHeaderResponseModel>> ByCustomerID(int customerID);
                Task<List<ApiSalesOrderHeaderResponseModel>> BySalesPersonID(Nullable<int> salesPersonID);

                Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>58286851884a6727af5852b5c4eb73ee</Hash>
</Codenesium>*/