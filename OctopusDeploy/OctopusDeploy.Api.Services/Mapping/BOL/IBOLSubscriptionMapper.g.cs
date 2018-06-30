using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLSubscriptionMapper
        {
                BOSubscription MapModelToBO(
                        string id,
                        ApiSubscriptionRequestModel model);

                ApiSubscriptionResponseModel MapBOToModel(
                        BOSubscription boSubscription);

                List<ApiSubscriptionResponseModel> MapBOToModel(
                        List<BOSubscription> items);
        }
}

/*<Codenesium>
    <Hash>69a5b53a8864247e3102597980903e13</Hash>
</Codenesium>*/