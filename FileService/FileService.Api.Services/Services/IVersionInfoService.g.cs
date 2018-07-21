using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
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
    <Hash>d013d24d85b73fb0d85bb72e150eb059</Hash>
</Codenesium>*/