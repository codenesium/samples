using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
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
				model.AboutMe,
				model.AccountId,
				model.Age,
				model.CreationDate,
				model.DisplayName,
				model.DownVote,
				model.EmailHash,
				model.LastAccessDate,
				model.Location,
				model.Reputation,
				model.UpVote,
				model.View,
				model.WebsiteUrl);
			return item;
		}

		public virtual ApiUserServerResponseModel MapEntityToModel(
			User item)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AboutMe,
			                    item.AccountId,
			                    item.Age,
			                    item.CreationDate,
			                    item.DisplayName,
			                    item.DownVote,
			                    item.EmailHash,
			                    item.LastAccessDate,
			                    item.Location,
			                    item.Reputation,
			                    item.UpVote,
			                    item.View,
			                    item.WebsiteUrl);

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
    <Hash>61a499c6e11b51fa0efab92da63037d6</Hash>
</Codenesium>*/