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

                Task<List<ApiBucketResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiBucketResponseModel> GetExternalId(Guid externalId);
                Task<ApiBucketResponseModel> GetName(string name);

                Task<List<ApiFileResponseModel>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>82c84306fab2d5e2b9647d2070076662</Hash>
</Codenesium>*/