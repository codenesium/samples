using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>8b47422ae7af934485b45bb47b280a26</Hash>
</Codenesium>*/