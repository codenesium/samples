using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>6fc8ff22c66c8d309913f0a07a6b180b</Hash>
</Codenesium>*/