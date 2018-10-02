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
				model.Username);
			return boUser;
		}

		public virtual ApiUserResponseModel MapBOToModel(
			BOUser boUser)
		{
			var model = new ApiUserResponseModel();

			model.SetProperties(boUser.Id, boUser.Password, boUser.Username);

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
    <Hash>1913ae9159be01b2e94d409255bf5240</Hash>
</Codenesium>*/