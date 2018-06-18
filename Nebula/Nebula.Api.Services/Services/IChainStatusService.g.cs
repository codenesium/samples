using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IChainStatusService
        {
                Task<CreateResponse<ApiChainStatusResponseModel>> Create(
                        ApiChainStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiChainStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiChainStatusResponseModel> Get(int id);

                Task<List<ApiChainStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>798aab98360c3f72cd057797bb430db4</Hash>
</Codenesium>*/