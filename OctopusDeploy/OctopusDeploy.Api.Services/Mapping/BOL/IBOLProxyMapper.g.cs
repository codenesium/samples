using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLProxyMapper
        {
                BOProxy MapModelToBO(
                        string id,
                        ApiProxyRequestModel model);

                ApiProxyResponseModel MapBOToModel(
                        BOProxy boProxy);

                List<ApiProxyResponseModel> MapBOToModel(
                        List<BOProxy> items);
        }
}

/*<Codenesium>
    <Hash>2cbabc83639882376a76cc8fae06b05a</Hash>
</Codenesium>*/