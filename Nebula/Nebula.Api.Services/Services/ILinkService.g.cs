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

                Task<List<ApiLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>847d1b577352086f58fe9f813e98cf00</Hash>
</Codenesium>*/