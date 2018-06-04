using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractAdminMapper
	{
		public virtual BOAdmin MapModelToBO(
			int id,
			ApiAdminRequestModel model
			)
		{
			BOAdmin BOAdmin = new BOAdmin();

			BOAdmin.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
			return BOAdmin;
		}

		public virtual ApiAdminResponseModel MapBOToModel(
			BOAdmin BOAdmin)
		{
			if (BOAdmin == null)
			{
				return null;
			}

			var model = new ApiAdminResponseModel();

			model.SetProperties(BOAdmin.Birthday, BOAdmin.Email, BOAdmin.FirstName, BOAdmin.Id, BOAdmin.LastName, BOAdmin.Phone, BOAdmin.StudioId);

			return model;
		}

		public virtual List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> BOs)
		{
			List<ApiAdminResponseModel> response = new List<ApiAdminResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cf3bd9ac14e645e8000b68e74580e23e</Hash>
</Codenesium>*/