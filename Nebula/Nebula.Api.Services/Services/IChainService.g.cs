using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IChainService
        {
                Task<CreateResponse<ApiChainResponseModel>> Create(
                        ApiChainRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiChainRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiChainResponseModel> Get(int id);

                Task<List<ApiChainResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiClaspResponseModel>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b9ccb3b52f6501079d77af20b8d609d5</Hash>
</Codenesium>*/