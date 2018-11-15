using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractUserMapper
	{
		public virtual BOUser MapModelToBO(
			int id,
			ApiUserServerRequestModel model
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

		public virtual ApiUserServerResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(boUser.Id, boUser.AboutMe, boUser.AccountId, boUser.Age, boUser.CreationDate, boUser.DisplayName, boUser.DownVote, boUser.EmailHash, boUser.LastAccessDate, boUser.Location, boUser.Reputation, boUser.UpVote, boUser.View, boUser.WebsiteUrl);

			return model;
		}

		public virtual List<ApiUserServerResponseModel> MapBOToModel(
			List<BOUser> items)
		{
			List<ApiUserServerResponseModel> response = new List<ApiUserServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0af088050793c511c8336be9a888d906</Hash>
</Codenesium>*/