using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAddressMapper
	{
		public virtual Address MapModelToEntity(
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

		public virtual ApiAddressServerResponseModel MapEntityToModel(
			Address item)
		{
			var model = new ApiAddressServerResponseModel();

			model.SetProperties(item.AddressID,
			                    item.AddressLine1,
			                    item.AddressLine2,
			                    item.City,
			                    item.ModifiedDate,
			                    item.PostalCode,
			                    item.Rowguid,
			                    item.StateProvinceID);
			if (item.StateProvinceIDNavigation != null)
			{
				var stateProvinceIDModel = new ApiStateProvinceServerResponseModel();
				stateProvinceIDModel.SetProperties(
					item.StateProvinceIDNavigation.StateProvinceID,
					item.StateProvinceIDNavigation.CountryRegionCode,
					item.StateProvinceIDNavigation.IsOnlyStateProvinceFlag,
					item.StateProvinceIDNavigation.ModifiedDate,
					item.StateProvinceIDNavigation.Name,
					item.StateProvinceIDNavigation.Rowguid,
					item.StateProvinceIDNavigation.StateProvinceCode,
					item.StateProvinceIDNavigation.TerritoryID);

				model.SetStateProvinceIDNavigation(stateProvinceIDModel);
			}

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
    <Hash>891004d3bc3016d99b1d34124fe41724</Hash>
</Codenesium>*/