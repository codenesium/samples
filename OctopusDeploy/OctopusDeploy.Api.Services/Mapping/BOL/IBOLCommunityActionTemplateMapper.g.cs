using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>8af30757a483c008c6f00d77044991c7</Hash>
</Codenesium>*/