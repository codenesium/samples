using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>463d5fe09b5e151b011d72998da781fd</Hash>
</Codenesium>*/