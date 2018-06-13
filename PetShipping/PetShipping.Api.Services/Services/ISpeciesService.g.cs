using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                Task<List<ApiSpeciesResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiBreedResponseModel>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>35869eca6e61446066d8ba347e6eac2b</Hash>
</Codenesium>*/