using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISpecialOfferService
        {
                Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
                        ApiSpecialOfferRequestModel model);

                Task<ActionResponse> Update(int specialOfferID,
                                            ApiSpecialOfferRequestModel model);

                Task<ActionResponse> Delete(int specialOfferID);

                Task<ApiSpecialOfferResponseModel> Get(int specialOfferID);

                Task<List<ApiSpecialOfferResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6b3221a66927cb1c1818db0c5ce57265</Hash>
</Codenesium>*/