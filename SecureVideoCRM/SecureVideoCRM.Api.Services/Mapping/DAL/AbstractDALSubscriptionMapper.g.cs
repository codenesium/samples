using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractDALSubscriptionMapper
	{
		public virtual Subscription MapModelToEntity(
			int id,
			ApiSubscriptionServerRequestModel model
			)
		{
			Subscription item = new Subscription();
			item.SetProperties(
				id,
				model.Name,
				model.StripePlanName);
			return item;
		}

		public virtual ApiSubscriptionServerResponseModel MapEntityToModel(
			Subscription item)
		{
			var model = new ApiSubscriptionServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.StripePlanName);

			return model;
		}

		public virtual List<ApiSubscriptionServerResponseModel> MapEntityToModel(
			List<Subscription> items)
		{
			List<ApiSubscriptionServerResponseModel> response = new List<ApiSubscriptionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c5104d5d7cb4fe6a658115e3311ab871</Hash>
</Codenesium>*/