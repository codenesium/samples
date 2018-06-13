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

                Task<List<ApiChainStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>783a71b0c5a40abb9022662601e838e3</Hash>
</Codenesium>*/