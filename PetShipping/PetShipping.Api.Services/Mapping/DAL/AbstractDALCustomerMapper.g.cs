using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>dbf8b166f59b311846ea0a779c499c91</Hash>
</Codenesium>*/