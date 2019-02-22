using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALAddressMapper
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
    <Hash>4c97b634a3db81790765f9f460cb2ea1</Hash>
</Codenesium>*/