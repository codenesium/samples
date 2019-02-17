using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAddressTypeMapper
	{
		public virtual AddressType MapModelToEntity(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model
			)
		{
			AddressType item = new AddressType();
			item.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return item;
		}

		public virtual ApiAddressTypeServerResponseModel MapEntityToModel(
			AddressType item)
		{
			var model = new ApiAddressTypeServerResponseModel();

			model.SetProperties(item.AddressTypeID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeServerResponseModel> MapEntityToModel(
			List<AddressType> items)
		{
			List<ApiAddressTypeServerResponseModel> response = new List<ApiAddressTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2a27d8c9e505ac046670dd2de8efd1b6</Hash>
</Codenesium>*/