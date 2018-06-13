using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>ef7b219fa0142f0f7d4870327d06374a</Hash>
</Codenesium>*/