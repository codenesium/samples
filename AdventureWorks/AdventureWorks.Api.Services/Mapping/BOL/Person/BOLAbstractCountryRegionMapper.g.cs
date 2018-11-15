using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCountryRegionMapper
	{
		public virtual BOCountryRegion MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel model
			)
		{
			BOCountryRegion boCountryRegion = new BOCountryRegion();
			boCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
			return boCountryRegion;
		}

		public virtual ApiCountryRegionServerResponseModel MapBOToModel(
			BOCountryRegion boCountryRegion)
		{
			var model = new ApiCountryRegionServerResponseModel();

			model.SetProperties(boCountryRegion.CountryRegionCode, boCountryRegion.ModifiedDate, boCountryRegion.Name);

			return model;
		}

		public virtual List<ApiCountryRegionServerResponseModel> MapBOToModel(
			List<BOCountryRegion> items)
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
    <Hash>7592b0df7e97ebe52954e6e8c70bcf9f</Hash>
</Codenesium>*/