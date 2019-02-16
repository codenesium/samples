using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALAdminMapper
	{
		public virtual Admin MapModelToEntity(
			int id,
			ApiAdminServerRequestModel model
			)
		{
			Admin item = new Admin();
			item.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Password,
				model.Phone,
				model.Username);
			return item;
		}

		public virtual ApiAdminServerResponseModel MapEntityToModel(
			Admin item)
		{
			var model = new ApiAdminServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Password,
			                    item.Phone,
			                    item.Username);

			return model;
		}

		public virtual List<ApiAdminServerResponseModel> MapEntityToModel(
			List<Admin> items)
		{
			List<ApiAdminServerResponseModel> response = new List<ApiAdminServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1b35b0f20a89739f52ddbc00cc401f6c</Hash>
</Codenesium>*/