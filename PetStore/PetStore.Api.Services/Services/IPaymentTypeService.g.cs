using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IPaymentTypeService
        {
                Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
                        ApiPaymentTypeRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPaymentTypeRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPaymentTypeResponseModel> Get(int id);

                Task<List<ApiPaymentTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSaleResponseModel>> Sales(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>76c0d90d3a41842903423064affaa910</Hash>
</Codenesium>*/