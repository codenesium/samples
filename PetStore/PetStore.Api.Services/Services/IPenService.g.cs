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

                Task<List<ApiPenResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPetResponseModel>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1396f4f7bdedec478eb39b6e6bb75234</Hash>
</Codenesium>*/