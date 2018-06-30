using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLActionTemplateMapper
        {
                BOActionTemplate MapModelToBO(
                        string id,
                        ApiActionTemplateRequestModel model);

                ApiActionTemplateResponseModel MapBOToModel(
                        BOActionTemplate boActionTemplate);

                List<ApiActionTemplateResponseModel> MapBOToModel(
                        List<BOActionTemplate> items);
        }
}

/*<Codenesium>
    <Hash>66d7237e38fc0092a3218a6492c1e8de</Hash>
</Codenesium>*/