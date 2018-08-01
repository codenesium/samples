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
    <Hash>d512f4b5c239860096f6ca7bdc45b2d3</Hash>
</Codenesium>*/