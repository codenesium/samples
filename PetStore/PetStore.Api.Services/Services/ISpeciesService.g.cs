using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface ISpeciesService
        {
                Task<CreateResponse<ApiSpeciesResponseModel>> Create(
                        ApiSpeciesRequestModel model);

                Task<UpdateResponse<ApiSpeciesResponseModel>> Update(int id,
                                                                      ApiSpeciesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpeciesResponseModel> Get(int id);

                Task<List<ApiSpeciesResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPetResponseModel>> Pets(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>15aa1a72b0199cb6c57274b8980b428a</Hash>
</Codenesium>*/