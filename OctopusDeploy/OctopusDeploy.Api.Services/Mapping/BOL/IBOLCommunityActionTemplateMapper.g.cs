using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLCommunityActionTemplateMapper
        {
                BOCommunityActionTemplate MapModelToBO(
                        string id,
                        ApiCommunityActionTemplateRequestModel model);

                ApiCommunityActionTemplateResponseModel MapBOToModel(
                        BOCommunityActionTemplate boCommunityActionTemplate);

                List<ApiCommunityActionTemplateResponseModel> MapBOToModel(
                        List<BOCommunityActionTemplate> items);
        }
}

/*<Codenesium>
    <Hash>8ad9ce85d888c616b25c8c1fecf5dc87</Hash>
</Codenesium>*/