using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface ISpeciesService
        {
                Task<CreateResponse<ApiSpeciesResponseModel>> Create(
                        ApiSpeciesRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSpeciesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpeciesResponseModel> Get(int id);

                Task<List<ApiSpeciesResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBreedResponseModel>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2bdce99da676c37b7f132932e2ebfd68</Hash>
</Codenesium>*/