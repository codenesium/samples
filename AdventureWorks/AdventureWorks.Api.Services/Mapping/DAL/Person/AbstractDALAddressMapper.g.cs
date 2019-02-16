using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAddressMapper
	{
		public virtual Address MapModelToBO(
			int addressID,
			ApiAddressServerRequestModel model
			)
		{
			Address item = new Address();
			item.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.ModifiedDate,
				model.PostalCode,
				model.Rowguid,
				model.StateProvinceID);
			return item;
		}

		public virtual ApiAddressServerResponseModel MapBOToModel(
			Address item)
		{
			var model = new ApiAddressServerResponseModel();

			model.SetProperties(item.AddressID, item.AddressLine1, item.AddressLine2, item.City, item.ModifiedDate, item.PostalCode, item.Rowguid, item.StateProvinceID);

			return model;
		}

		public virtual List<ApiAddressServerResponseModel> MapBOToModel(
			List<Address> items)
		{
			List<ApiAddressServerResponseModel> response = new List<ApiAddressServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c6ddbb2555811e2d64eb5588e8646627</Hash>
</Codenesium>*/