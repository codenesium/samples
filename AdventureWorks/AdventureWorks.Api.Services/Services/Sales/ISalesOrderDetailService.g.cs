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

                Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>54909b0b1f586f9fd24f757a96978f1b</Hash>
</Codenesium>*/