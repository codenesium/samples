using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ICommunityActionTemplateService
        {
                Task<CreateResponse<ApiCommunityActionTemplateResponseModel>> Create(
                        ApiCommunityActionTemplateRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiCommunityActionTemplateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiCommunityActionTemplateResponseModel> Get(string id);

                Task<List<ApiCommunityActionTemplateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCommunityActionTemplateResponseModel> GetExternalId(Guid externalId);
                Task<ApiCommunityActionTemplateResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>da1e26c11cd930e118fb4250f52ff935</Hash>
</Codenesium>*/