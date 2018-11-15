using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class BOLAbstractAdminMapper
	{
		public virtual BOAdmin MapModelToBO(
			int id,
			ApiAdminServerRequestModel model
			)
		{
			BOAdmin boAdmin = new BOAdmin();
			boAdmin.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.UserId);
			return boAdmin;
		}

		public virtual ApiAdminServerResponseModel MapBOToModel(
			BOAdmin boAdmin)
		{
			var model = new ApiAdminServerResponseModel();

			model.SetProperties(boAdmin.Id, boAdmin.Birthday, boAdmin.Email, boAdmin.FirstName, boAdmin.LastName, boAdmin.Phone, boAdmin.UserId);

			return model;
		}

		public virtual List<ApiAdminServerResponseModel> MapBOToModel(
			List<BOAdmin> items)
		{
			List<ApiAdminServerResponseModel> response = new List<ApiAdminServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f2c2ab269ff1e764091efc506c4f5d1c</Hash>
</Codenesium>*/