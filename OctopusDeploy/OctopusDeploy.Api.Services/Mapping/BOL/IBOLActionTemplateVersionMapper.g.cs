using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>70c4276aab8febe3971c4c2c639a5f0c</Hash>
</Codenesium>*/