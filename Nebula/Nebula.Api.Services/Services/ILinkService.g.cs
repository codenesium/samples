using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface ILinkService
        {
                Task<CreateResponse<ApiLinkResponseModel>> Create(
                        ApiLinkRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLinkRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkResponseModel> Get(int id);

                Task<List<ApiLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9f3374e7bf800880be38514bfa9497eb</Hash>
</Codenesium>*/