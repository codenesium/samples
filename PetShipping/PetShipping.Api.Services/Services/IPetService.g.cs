using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPetService
        {
                Task<CreateResponse<ApiPetResponseModel>> Create(
                        ApiPetRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPetRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPetResponseModel> Get(int id);

                Task<List<ApiPetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleResponseModel>> Sales(int petId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fe6de273c734a80970255259b19e3cda</Hash>
</Codenesium>*/