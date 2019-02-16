using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAddressTypeMapper
	{
		public virtual AddressType MapModelToBO(
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

		public virtual ApiAddressTypeServerResponseModel MapBOToModel(
			AddressType item)
		{
			var model = new ApiAddressTypeServerResponseModel();

			model.SetProperties(item.AddressTypeID, item.ModifiedDate, item.Name, item.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeServerResponseModel> MapBOToModel(
			List<AddressType> items)
		{
			List<ApiAddressTypeServerResponseModel> response = new List<ApiAddressTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>668d22c85cc7b0e53b40bb02c60f4624</Hash>
</Codenesium>*/