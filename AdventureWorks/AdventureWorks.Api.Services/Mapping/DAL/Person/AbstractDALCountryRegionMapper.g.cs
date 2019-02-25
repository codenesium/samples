using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCountryRegionMapper
	{
		public virtual CountryRegion MapModelToEntity(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel model
			)
		{
			CountryRegion item = new CountryRegion();
			item.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiCountryRegionServerResponseModel MapEntityToModel(
			CountryRegion item)
		{
			var model = new ApiCountryRegionServerResponseModel();

			model.SetProperties(item.CountryRegionCode,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCountryRegionServerResponseModel> MapEntityToModel(
			List<CountryRegion> items)
		{
			List<ApiCountryRegionServerResponseModel> response = new List<ApiCountryRegionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d113b67fed03ca35f363b621461032c6</Hash>
</Codenesium>*/