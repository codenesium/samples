using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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

                Task<List<ApiPetResponseModel>> Pets(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f6129863df5885e023aa54a3f1460e6b</Hash>
</Codenesium>*/