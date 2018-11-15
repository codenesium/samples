using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractCustomerMapper
	{
		public virtual BOCustomer MapModelToBO(
			int id,
			ApiCustomerServerRequestModel model
			)
		{
			BOCustomer boCustomer = new BOCustomer();
			boCustomer.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return boCustomer;
		}

		public virtual ApiCustomerServerResponseModel MapBOToModel(
			BOCustomer boCustomer)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(boCustomer.Id, boCustomer.Email, boCustomer.FirstName, boCustomer.LastName, boCustomer.Phone);

			return model;
		}

		public virtual List<ApiCustomerServerResponseModel> MapBOToModel(
			List<BOCustomer> items)
		{
			List<ApiCustomerServerResponseModel> response = new List<ApiCustomerServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>09ec122a8de58a67d87d0b7010d9f8a0</Hash>
</Codenesium>*/