using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
				model.Password,
				model.Username);
			return boUser;
		}

		public virtual ApiUserServerResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(boUser.Id, boUser.Password, boUser.Username);

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
    <Hash>3c82b99f75745d83ef4228b87971aaca</Hash>
</Codenesium>*/