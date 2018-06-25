using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<ApiCommunityActionTemplateResponseModel> ByExternalId(Guid externalId);

                Task<ApiCommunityActionTemplateResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>3c3aec0287c671b01094959087e69563</Hash>
</Codenesium>*/