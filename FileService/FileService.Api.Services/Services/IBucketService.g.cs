using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b39e86b091f5b4f53da44a562911a295</Hash>
</Codenesium>*/