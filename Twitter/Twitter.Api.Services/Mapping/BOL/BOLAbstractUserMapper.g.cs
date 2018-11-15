using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractUserMapper
	{
		public virtual BOUser MapModelToBO(
			int userId,
			ApiUserServerRequestModel model
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

		public virtual ApiUserServerResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(boUser.UserId, boUser.BioImgUrl, boUser.Birthday, boUser.ContentDescription, boUser.Email, boUser.FullName, boUser.HeaderImgUrl, boUser.Interest, boUser.LocationLocationId, boUser.Password, boUser.PhoneNumber, boUser.Privacy, boUser.Username, boUser.Website);

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
    <Hash>a3ec0fe1e0591799fe531b56352347b5</Hash>
</Codenesium>*/