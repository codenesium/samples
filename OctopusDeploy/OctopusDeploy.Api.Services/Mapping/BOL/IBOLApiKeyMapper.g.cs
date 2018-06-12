using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLApiKeyMapper
        {
                BOApiKey MapModelToBO(
                        string id,
                        ApiApiKeyRequestModel model);

                ApiApiKeyResponseModel MapBOToModel(
                        BOApiKey boApiKey);

                List<ApiApiKeyResponseModel> MapBOToModel(
                        List<BOApiKey> items);
        }
}

/*<Codenesium>
    <Hash>0b538c816c735b6ce2017e181d0b9940</Hash>
</Codenesium>*/