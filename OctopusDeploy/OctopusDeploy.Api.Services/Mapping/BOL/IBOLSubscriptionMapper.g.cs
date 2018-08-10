using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLSubscriptionMapper
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
    <Hash>3524b44df4a60744d04bb537bf7f09aa</Hash>
</Codenesium>*/