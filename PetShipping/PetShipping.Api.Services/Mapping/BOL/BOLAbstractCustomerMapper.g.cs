using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.Note,
				model.Phone);
			return boCustomer;
		}

		public virtual ApiCustomerServerResponseModel MapBOToModel(
			BOCustomer boCustomer)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(boCustomer.Id, boCustomer.Email, boCustomer.FirstName, boCustomer.LastName, boCustomer.Note, boCustomer.Phone);

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
    <Hash>9c7ff4037457569ac670e31856e887cf</Hash>
</Codenesium>*/