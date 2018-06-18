using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISpecialOfferProductService
        {
                Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
                        ApiSpecialOfferProductRequestModel model);

                Task<ActionResponse> Update(int specialOfferID,
                                            ApiSpecialOfferProductRequestModel model);

                Task<ActionResponse> Delete(int specialOfferID);

                Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID);

                Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpecialOfferProductResponseModel>> ByProductID(int productID);

                Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>129229f6f62d7a8caa6bbf0cc6503aa3</Hash>
</Codenesium>*/