using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
				model.Email,
				model.FirstName,
				model.LastName,
				model.Password,
				model.Phone,
				model.Username);
			return boAdmin;
		}

		public virtual ApiAdminServerResponseModel MapBOToModel(
			BOAdmin boAdmin)
		{
			var model = new ApiAdminServerResponseModel();

			model.SetProperties(boAdmin.Id, boAdmin.Email, boAdmin.FirstName, boAdmin.LastName, boAdmin.Password, boAdmin.Phone, boAdmin.Username);

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
    <Hash>73a0944e2af69565cc59fd81340c5675</Hash>
</Codenesium>*/