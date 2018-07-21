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

                Task<UpdateResponse<ApiLinkStatusResponseModel>> Update(int id,
                                                                         ApiLinkStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkStatusResponseModel> Get(int id);

                Task<List<ApiLinkStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c3632f83ea76b6a868538bb28bc77645</Hash>
</Codenesium>*/