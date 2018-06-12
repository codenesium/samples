using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>d489fad479233c14cf8f69467c5454da</Hash>
</Codenesium>*/