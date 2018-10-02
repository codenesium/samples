using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractUserMapper
	{
		public virtual BOUser MapModelToBO(
			int id,
			ApiUserRequestModel model
			)
		{
			BOUser boUser = new BOUser();
			boUser.SetProperties(
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
			return boUser;
		}

		public virtual ApiUserResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserResponseModel();

			model.SetProperties(boUser.Id, boUser.AboutMe, boUser.AccountId, boUser.Age, boUser.CreationDate, boUser.DisplayName, boUser.DownVote, boUser.EmailHash, boUser.LastAccessDate, boUser.Location, boUser.Reputation, boUser.UpVote, boUser.View, boUser.WebsiteUrl);

			return model;
		}

		public virtual List<ApiUserResponseModel> MapBOToModel(
			List<BOUser> items)
		{
			List<ApiUserResponseModel> response = new List<ApiUserResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ee1285ce87aa0016185cab6d41d628eb</Hash>
</Codenesium>*/