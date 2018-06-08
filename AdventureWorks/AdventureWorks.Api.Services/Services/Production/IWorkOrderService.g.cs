using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IWorkOrderService
        {
                Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
                        ApiWorkOrderRequestModel model);

                Task<ActionResponse> Update(int workOrderID,
                                            ApiWorkOrderRequestModel model);

                Task<ActionResponse> Delete(int workOrderID);

                Task<ApiWorkOrderResponseModel> Get(int workOrderID);

                Task<List<ApiWorkOrderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiWorkOrderResponseModel>> GetProductID(int productID);
                Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID);
        }
}

/*<Codenesium>
    <Hash>34dc95292727ebfda2283926944b65f6</Hash>
</Codenesium>*/