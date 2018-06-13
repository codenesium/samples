using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                Task<List<ApiBreedResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c6d46ad7b8503d787cda6844d9e5a0a4</Hash>
</Codenesium>*/