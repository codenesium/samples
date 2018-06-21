using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f86a422d4d78c8f31281306c1b251856</Hash>
</Codenesium>*/