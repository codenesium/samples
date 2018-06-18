using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface ILinkLogService
        {
                Task<CreateResponse<ApiLinkLogResponseModel>> Create(
                        ApiLinkLogRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLinkLogRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkLogResponseModel> Get(int id);

                Task<List<ApiLinkLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>753da874bbd646fe8b8d739617f5fc49</Hash>
</Codenesium>*/