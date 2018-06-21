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

                Task<ActionResponse> Update(long version,
                                            ApiVersionInfoRequestModel model);

                Task<ActionResponse> Delete(long version);

                Task<ApiVersionInfoResponseModel> Get(long version);

                Task<List<ApiVersionInfoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiVersionInfoResponseModel> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>014b89f987667f82593741cbe6ca7a5c</Hash>
</Codenesium>*/