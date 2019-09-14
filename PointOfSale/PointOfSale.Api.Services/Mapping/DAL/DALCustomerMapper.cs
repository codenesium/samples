using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
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
    <Hash>2a6815a2f45b27248d5043739827b0fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/