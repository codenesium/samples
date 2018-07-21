using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IPetService
        {
                Task<CreateResponse<ApiPetResponseModel>> Create(
                        ApiPetRequestModel model);

                Task<UpdateResponse<ApiPetResponseModel>> Update(int id,
                                                                  ApiPetRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPetResponseModel> Get(int id);

                Task<List<ApiPetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleResponseModel>> Sales(int petId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a90c7ebc0be0c7a59f4f4adb91d41bd8</Hash>
</Codenesium>*/