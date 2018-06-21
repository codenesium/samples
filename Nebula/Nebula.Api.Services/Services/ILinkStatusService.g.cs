using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface ILinkStatusService
        {
                Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
                        ApiLinkStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLinkStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkStatusResponseModel> Get(int id);

                Task<List<ApiLinkStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c7ad01f1b5767dd2d1824c92cf03e962</Hash>
</Codenesium>*/