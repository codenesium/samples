using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
				model.Password,
				model.Username,
				model.IsDeleted);
			return boUser;
		}

		public virtual ApiUserResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserResponseModel();

			model.SetProperties(boUser.Id, boUser.Password, boUser.Username, boUser.IsDeleted);

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
    <Hash>e8315495a937566cb4d06527ef09a10e</Hash>
</Codenesium>*/