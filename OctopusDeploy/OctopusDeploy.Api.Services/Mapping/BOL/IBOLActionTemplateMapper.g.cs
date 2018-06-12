using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>df2b945fbadfdc18dc29100ac1fc06bf</Hash>
</Codenesium>*/