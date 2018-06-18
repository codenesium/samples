using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface ISaleService
        {
                Task<CreateResponse<ApiSaleResponseModel>> Create(
                        ApiSaleRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSaleRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSaleResponseModel> Get(int id);

                Task<List<ApiSaleResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a87de8c003175fd26701da8948351d8b</Hash>
</Codenesium>*/