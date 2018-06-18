using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>44cadc56a5e4e222b13658969e05aace</Hash>
</Codenesium>*/