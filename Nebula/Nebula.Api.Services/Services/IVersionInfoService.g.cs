using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IVersionInfoService
        {
                Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
                        ApiVersionInfoRequestModel model);

                Task<UpdateResponse<ApiVersionInfoResponseModel>> Update(long version,
                                                                          ApiVersionInfoRequestModel model);

                Task<ActionResponse> Delete(long version);

                Task<ApiVersionInfoResponseModel> Get(long version);

                Task<List<ApiVersionInfoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiVersionInfoResponseModel> ByVersion(long version);
        }
}

/*<Codenesium>
    <Hash>62ca809533c8daaff6a5e85e09c06455</Hash>
</Codenesium>*/