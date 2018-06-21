using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>092905221d0e43fdfb75ebcb89c34373</Hash>
</Codenesium>*/