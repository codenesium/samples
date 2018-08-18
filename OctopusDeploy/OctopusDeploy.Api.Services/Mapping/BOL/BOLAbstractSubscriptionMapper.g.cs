using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractSubscriptionMapper
	{
		public virtual BOSubscription MapModelToBO(
			string id,
			ApiSubscriptionRequestModel model
			)
		{
			BOSubscription boSubscription = new BOSubscription();
			boSubscription.SetProperties(
				id,
				model.IsDisabled,
				model.JSON,
				model.Name,
				model.Type);
			return boSubscription;
		}

		public virtual ApiSubscriptionResponseModel MapBOToModel(
			BOSubscription boSubscription)
		{
			var model = new ApiSubscriptionResponseModel();

			model.SetProperties(boSubscription.Id, boSubscription.IsDisabled, boSubscription.JSON, boSubscription.Name, boSubscription.Type);

			return model;
		}

		public virtual List<ApiSubscriptionResponseModel> MapBOToModel(
			List<BOSubscription> items)
		{
			List<ApiSubscriptionResponseModel> response = new List<ApiSubscriptionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9dabe1784b87c161f3c01f3b8a7bae5</Hash>
</Codenesium>*/