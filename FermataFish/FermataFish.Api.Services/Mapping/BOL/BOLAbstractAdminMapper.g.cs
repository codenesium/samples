using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				model.StudioId);
			return boAdmin;
		}

		public virtual ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin)
		{
			var model = new ApiAdminResponseModel();

			model.SetProperties(boAdmin.Id, boAdmin.Birthday, boAdmin.Email, boAdmin.FirstName, boAdmin.LastName, boAdmin.Phone, boAdmin.StudioId);

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
    <Hash>b85db710f23a4530d3ac348189219001</Hash>
</Codenesium>*/