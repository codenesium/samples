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

                Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSpecialOfferProductResponseModel>> GetProductID(int productID);

                Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9a44de2d6738fe8fe019b9529ef2a0f9</Hash>
</Codenesium>*/