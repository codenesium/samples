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
    <Hash>a8d3a9c249955820c80bd61e362677a7</Hash>
</Codenesium>*/