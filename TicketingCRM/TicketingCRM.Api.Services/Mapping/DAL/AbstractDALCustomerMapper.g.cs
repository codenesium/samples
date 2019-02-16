using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALCustomerMapper
	{
		public virtual Customer MapModelToEntity(
			int id,
			ApiCustomerServerRequestModel model
			)
		{
			Customer item = new Customer();
			item.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return item;
		}

		public virtual ApiCustomerServerResponseModel MapEntityToModel(
			Customer item)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone);

			return model;
		}

		public virtual List<ApiCustomerServerResponseModel> MapEntityToModel(
			List<Customer> items)
		{
			List<ApiCustomerServerResponseModel> response = new List<ApiCustomerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ff0e9441b07d69d59fb5275b8317b5b4</Hash>
</Codenesium>*/