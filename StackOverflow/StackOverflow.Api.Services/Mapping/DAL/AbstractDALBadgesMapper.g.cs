using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALBadgesMapper
	{
		public virtual Badges MapModelToEntity(
			int id,
			ApiBadgesServerRequestModel model
			)
		{
			Badges item = new Badges();
			item.SetProperties(
				id,
				model.Date,
				model.Name,
				model.UserId);
			return item;
		}

		public virtual ApiBadgesServerResponseModel MapEntityToModel(
			Badges item)
		{
			var model = new ApiBadgesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Date,
			                    item.Name,
			                    item.UserId);
			if (item.UserIdNavigation != null)
			{
				var userIdModel = new ApiUsersServerResponseModel();
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

		public virtual List<ApiBadgesServerResponseModel> MapEntityToModel(
			List<Badges> items)
		{
			List<ApiBadgesServerResponseModel> response = new List<ApiBadgesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>255669e4d239e285e8df7fd9dcc7343a</Hash>
</Codenesium>*/