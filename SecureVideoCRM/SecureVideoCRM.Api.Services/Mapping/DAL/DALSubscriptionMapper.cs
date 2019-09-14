using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public class DALSubscriptionMapper : IDALSubscriptionMapper
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
    <Hash>de30a751c36dec55c5d5aac38a837a84</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/