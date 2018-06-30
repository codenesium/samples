using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d88bbddfd954fd705e2a109f47f55813</Hash>
</Codenesium>*/