using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IAdminService
        {
                Task<CreateResponse<ApiAdminResponseModel>> Create(
                        ApiAdminRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiAdminRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiAdminResponseModel> Get(int id);

                Task<List<ApiAdminResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1f55de2b2463772031f9b5b9b77f7f45</Hash>
</Codenesium>*/