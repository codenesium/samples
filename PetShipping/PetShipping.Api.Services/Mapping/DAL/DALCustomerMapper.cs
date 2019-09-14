using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALCustomerMapper : IDALCustomerMapper
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
				model.Notes,
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
			                    item.Notes,
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
    <Hash>ae67025c63d61961ad87fc2c14e343c9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/