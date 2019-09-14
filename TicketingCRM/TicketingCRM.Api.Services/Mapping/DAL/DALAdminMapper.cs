using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALAdminMapper : IDALAdminMapper
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
    <Hash>9757f51ac0db6cc8eb149fe79579c663</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/