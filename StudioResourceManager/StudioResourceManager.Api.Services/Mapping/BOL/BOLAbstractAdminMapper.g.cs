using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractAdminMapper
	{
		public virtual BOAdmin MapModelToBO(
			int id,
			ApiAdminRequestModel model
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
				model.UserId,
				model.IsDeleted);
			return boAdmin;
		}

		public virtual ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin)
		{
			var model = new ApiAdminResponseModel();

			model.SetProperties(boAdmin.Id, boAdmin.Birthday, boAdmin.Email, boAdmin.FirstName, boAdmin.LastName, boAdmin.Phone, boAdmin.UserId, boAdmin.IsDeleted);

			return model;
		}

		public virtual List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> items)
		{
			List<ApiAdminResponseModel> response = new List<ApiAdminResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3dad86d46b10d25958b6e9194d9e0721</Hash>
</Codenesium>*/