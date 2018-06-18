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

                Task<List<ApiCommunityActionTemplateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCommunityActionTemplateResponseModel> GetExternalId(Guid externalId);
                Task<ApiCommunityActionTemplateResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>05d22b15be49a8b5504247bcbe593df0</Hash>
</Codenesium>*/