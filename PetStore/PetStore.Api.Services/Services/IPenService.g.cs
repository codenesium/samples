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

                Task<List<ApiPenResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a8e6725cb13938ae3e9e2d4609d24678</Hash>
</Codenesium>*/