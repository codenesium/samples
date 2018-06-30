using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IBreedService
        {
                Task<CreateResponse<ApiBreedResponseModel>> Create(
                        ApiBreedRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiBreedRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiBreedResponseModel> Get(int id);

                Task<List<ApiBreedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9204cfd02101bb5da639caf71470e719</Hash>
</Codenesium>*/