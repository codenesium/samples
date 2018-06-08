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

                Task<List<ApiBucketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiBucketResponseModel> GetExternalId(Guid externalId);
                Task<ApiBucketResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>5ba726b2a4c2a23371f32d41818b73c2</Hash>
</Codenesium>*/