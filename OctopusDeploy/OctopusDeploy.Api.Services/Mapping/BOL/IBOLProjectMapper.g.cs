using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLProjectMapper
        {
                BOProject MapModelToBO(
                        string id,
                        ApiProjectRequestModel model);

                ApiProjectResponseModel MapBOToModel(
                        BOProject boProject);

                List<ApiProjectResponseModel> MapBOToModel(
                        List<BOProject> items);
        }
}

/*<Codenesium>
    <Hash>f0537b3c7f4caaed5c707dcccb1fd0bb</Hash>
</Codenesium>*/