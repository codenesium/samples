using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface ISaleService
        {
                Task<CreateResponse<ApiSaleResponseModel>> Create(
                        ApiSaleRequestModel model);

                Task<UpdateResponse<ApiSaleResponseModel>> Update(int id,
                                                                   ApiSaleRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSaleResponseModel> Get(int id);

                Task<List<ApiSaleResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>550e2b803b9fca414acc078eeb85379d</Hash>
</Codenesium>*/