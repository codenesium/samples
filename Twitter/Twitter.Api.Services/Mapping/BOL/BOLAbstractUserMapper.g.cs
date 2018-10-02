using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractUserMapper
	{
		public virtual BOUser MapModelToBO(
			int userId,
			ApiUserRequestModel model
			)
		{
			BOUser boUser = new BOUser();
			boUser.SetProperties(
				userId,
				model.BioImgUrl,
				model.Birthday,
				model.ContentDescription,
				model.Email,
				model.FullName,
				model.HeaderImgUrl,
				model.Interest,
				model.LocationLocationId,
				model.Password,
				model.PhoneNumber,
				model.Privacy,
				model.Username,
				model.Website);
			return boUser;
		}

		public virtual ApiUserResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserResponseModel();

			model.SetProperties(boUser.UserId, boUser.BioImgUrl, boUser.Birthday, boUser.ContentDescription, boUser.Email, boUser.FullName, boUser.HeaderImgUrl, boUser.Interest, boUser.LocationLocationId, boUser.Password, boUser.PhoneNumber, boUser.Privacy, boUser.Username, boUser.Website);

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
    <Hash>15a272e8d9bdeca140cb113903bf9ab0</Hash>
</Codenesium>*/