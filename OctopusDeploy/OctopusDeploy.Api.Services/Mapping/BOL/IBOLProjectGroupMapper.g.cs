using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>e77f804b25f963725145e09f3231c299</Hash>
</Codenesium>*/