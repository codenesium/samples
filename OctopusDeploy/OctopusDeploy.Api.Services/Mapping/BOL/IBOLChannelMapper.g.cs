using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLChannelMapper
        {
                BOChannel MapModelToBO(
                        string id,
                        ApiChannelRequestModel model);

                ApiChannelResponseModel MapBOToModel(
                        BOChannel boChannel);

                List<ApiChannelResponseModel> MapBOToModel(
                        List<BOChannel> items);
        }
}

/*<Codenesium>
    <Hash>d1103098415851cb54462e89838d442f</Hash>
</Codenesium>*/