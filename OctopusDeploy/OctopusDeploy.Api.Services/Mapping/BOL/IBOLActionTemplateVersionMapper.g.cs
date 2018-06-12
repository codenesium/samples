using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLActionTemplateVersionMapper
        {
                BOActionTemplateVersion MapModelToBO(
                        string id,
                        ApiActionTemplateVersionRequestModel model);

                ApiActionTemplateVersionResponseModel MapBOToModel(
                        BOActionTemplateVersion boActionTemplateVersion);

                List<ApiActionTemplateVersionResponseModel> MapBOToModel(
                        List<BOActionTemplateVersion> items);
        }
}

/*<Codenesium>
    <Hash>5306fa1102f558fdd584422ab0dfd602</Hash>
</Codenesium>*/