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

                Task<List<ApiSpecialOfferResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2a0ba1da5722aa516569079485e2c5bf</Hash>
</Codenesium>*/