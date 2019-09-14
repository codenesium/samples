using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALAddressMapper : IDALAddressMapper
	{
		public virtual Address MapModelToEntity(
			int id,
			ApiAddressServerRequestModel model
			)
		{
			Address item = new Address();
			item.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.State,
				model.Zip);
			return item;
		}

		public virtual ApiAddressServerResponseModel MapEntityToModel(
			Address item)
		{
			var model = new ApiAddressServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Address1,
			                    item.Address2,
			                    item.City,
			                    item.State,
			                    item.Zip);

			return model;
		}

		public virtual List<ApiAddressServerResponseModel> MapEntityToModel(
			List<Address> items)
		{
			List<ApiAddressServerResponseModel> response = new List<ApiAddressServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b1db5a3be051b2832d32b9c0b7e1bd2c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/