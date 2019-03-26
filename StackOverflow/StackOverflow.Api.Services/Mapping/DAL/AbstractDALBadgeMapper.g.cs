using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALBadgeMapper
	{
		public virtual Badge MapModelToEntity(
			int id,
			ApiBadgeServerRequestModel model
			)
		{
			Badge item = new Badge();
			item.SetProperties(
				id,
				model.Date,
				model.Name,
				model.UserId);
			return item;
		}

		public virtual ApiBadgeServerResponseModel MapEntityToModel(
			Badge item)
		{
			var model = new ApiBadgeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Date,
			                    item.Name,
			                    item.UserId);
			if (item.UserIdNavigation != null)
			{
				var userIdModel = new ApiUserServerResponseModel();
				userIdModel.SetProperties(
					item.UserIdNavigation.Id,
					item.UserIdNavigation.AboutMe,
					item.UserIdNavigation.AccountId,
					item.UserIdNavigation.Age,
					item.UserIdNavigation.CreationDate,
					item.UserIdNavigation.DisplayName,
					item.UserIdNavigation.DownVote,
					item.UserIdNavigation.EmailHash,
					item.UserIdNavigation.LastAccessDate,
					item.UserIdNavigation.Location,
					item.UserIdNavigation.Reputation,
					item.UserIdNavigation.UpVote,
					item.UserIdNavigation.View,
					item.UserIdNavigation.WebsiteUrl);

				model.SetUserIdNavigation(userIdModel);
			}

			return model;
		}

		public virtual List<ApiBadgeServerResponseModel> MapEntityToModel(
			List<Badge> items)
		{
			List<ApiBadgeServerResponseModel> response = new List<ApiBadgeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8c4d7056ad0b27097f99c691e07f60aa</Hash>
</Codenesium>*/