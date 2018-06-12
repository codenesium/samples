using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLProjectGroupMapper
        {
                BOProjectGroup MapModelToBO(
                        string id,
                        ApiProjectGroupRequestModel model);

                ApiProjectGroupResponseModel MapBOToModel(
                        BOProjectGroup boProjectGroup);

                List<ApiProjectGroupResponseModel> MapBOToModel(
                        List<BOProjectGroup> items);
        }
}

/*<Codenesium>
    <Hash>743eaa9de4302a5a569c833e922d2188</Hash>
</Codenesium>*/