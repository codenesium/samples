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

                Task<List<ApiSpecialOfferProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiSpecialOfferProductResponseModel>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>eb486654bd78466be0e31a0d73e56ae1</Hash>
</Codenesium>*/