using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IPetService
        {
                Task<CreateResponse<ApiPetResponseModel>> Create(
                        ApiPetRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPetRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPetResponseModel> Get(int id);

                Task<List<ApiPetResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSaleResponseModel>> Sales(int petId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b51ebdd6d6619441faa7a5d1658bb039</Hash>
</Codenesium>*/