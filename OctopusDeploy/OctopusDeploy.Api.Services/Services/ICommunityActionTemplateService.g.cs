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

                Task<List<ApiCommunityActionTemplateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiCommunityActionTemplateResponseModel> GetExternalId(Guid externalId);
                Task<ApiCommunityActionTemplateResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b3ba633481bd05358b52c888ce78d3ce</Hash>
</Codenesium>*/