using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCountryRegionMapper
	{
		public virtual CountryRegion MapModelToBO(
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

		public virtual ApiCountryRegionServerResponseModel MapBOToModel(
			CountryRegion item)
		{
			var model = new ApiCountryRegionServerResponseModel();

			model.SetProperties(item.CountryRegionCode, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiCountryRegionServerResponseModel> MapBOToModel(
			List<CountryRegion> items)
		{
			List<ApiCountryRegionServerResponseModel> response = new List<ApiCountryRegionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0bb2039e210b2dd3b6935229ca9da1d9</Hash>
</Codenesium>*/