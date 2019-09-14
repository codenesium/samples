using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALBadgeMapper : IDALBadgeMapper
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
    <Hash>50d6dc42dd5df3d8abfcf3e4a644e3f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/