using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IPenService
        {
                Task<CreateResponse<ApiPenResponseModel>> Create(
                        ApiPenRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPenRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPenResponseModel> Get(int id);

                Task<List<ApiPenResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPetResponseModel>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>be537c3508f9afb5ee811fb5331cfbb1</Hash>
</Codenesium>*/