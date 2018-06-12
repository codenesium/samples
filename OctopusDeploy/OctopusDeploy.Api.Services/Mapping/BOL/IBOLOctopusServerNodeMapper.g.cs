using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLOctopusServerNodeMapper
        {
                BOOctopusServerNode MapModelToBO(
                        string id,
                        ApiOctopusServerNodeRequestModel model);

                ApiOctopusServerNodeResponseModel MapBOToModel(
                        BOOctopusServerNode boOctopusServerNode);

                List<ApiOctopusServerNodeResponseModel> MapBOToModel(
                        List<BOOctopusServerNode> items);
        }
}

/*<Codenesium>
    <Hash>38c7beec93796f48c4ebacfe1c6dbe4f</Hash>
</Codenesium>*/