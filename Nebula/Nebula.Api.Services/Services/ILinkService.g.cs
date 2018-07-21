using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface ILinkService
        {
                Task<CreateResponse<ApiLinkResponseModel>> Create(
                        ApiLinkRequestModel model);

                Task<UpdateResponse<ApiLinkResponseModel>> Update(int id,
                                                                   ApiLinkRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkResponseModel> Get(int id);

                Task<List<ApiLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>90237b4c2af2fc5f589b5aa2aca40877</Hash>
</Codenesium>*/