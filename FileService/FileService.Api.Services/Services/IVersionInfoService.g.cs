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

                Task<ActionResponse> Update(long version,
                                            ApiVersionInfoRequestModel model);

                Task<ActionResponse> Delete(long version);

                Task<ApiVersionInfoResponseModel> Get(long version);

                Task<List<ApiVersionInfoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiVersionInfoResponseModel> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>3a7dc9087bf4256d47b2d41402b50160</Hash>
</Codenesium>*/