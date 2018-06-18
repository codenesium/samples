using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IBucketService
        {
                Task<CreateResponse<ApiBucketResponseModel>> Create(
                        ApiBucketRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiBucketRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiBucketResponseModel> Get(int id);

                Task<List<ApiBucketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiBucketResponseModel> GetExternalId(Guid externalId);
                Task<ApiBucketResponseModel> GetName(string name);

                Task<List<ApiFileResponseModel>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0937a6072a3342eb19182f0f84b4ca0a</Hash>
</Codenesium>*/