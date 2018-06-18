using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>7697f97f3a9185f986c7e5e9e4b55dff</Hash>
</Codenesium>*/