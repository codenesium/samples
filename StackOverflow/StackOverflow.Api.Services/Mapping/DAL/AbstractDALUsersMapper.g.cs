using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALUsersMapper
	{
		public virtual Users MapModelToEntity(
			int id,
			ApiUsersServerRequestModel model
			)
		{
			Users item = new Users();
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

		public virtual ApiUsersServerResponseModel MapEntityToModel(
			Users item)
		{
			var model = new ApiUsersServerResponseModel();

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

		public virtual List<ApiUsersServerResponseModel> MapEntityToModel(
			List<Users> items)
		{
			List<ApiUsersServerResponseModel> response = new List<ApiUsersServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e24309a12644993ba549453b8a681173</Hash>
</Codenesium>*/