using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractDALUserMapper
	{
		public virtual User MapModelToEntity(
			int id,
			ApiUserServerRequestModel model
			)
		{
			User item = new User();
			item.SetProperties(
				id,
				model.Email,
				model.Password,
				model.SubscriptionId);
			return item;
		}

		public virtual ApiUserServerResponseModel MapEntityToModel(
			User item)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Email,
			                    item.Password,
			                    item.SubscriptionId);
			if (item.SubscriptionIdNavigation != null)
			{
				var subscriptionIdModel = new ApiSubscriptionServerResponseModel();
				subscriptionIdModel.SetProperties(
					item.SubscriptionIdNavigation.Id,
					item.SubscriptionIdNavigation.Name);

				model.SetSubscriptionIdNavigation(subscriptionIdModel);
			}

			return model;
		}

		public virtual List<ApiUserServerResponseModel> MapEntityToModel(
			List<User> items)
		{
			List<ApiUserServerResponseModel> response = new List<ApiUserServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>048091b3124bf2a48becd27f6f7d3aa7</Hash>
</Codenesium>*/