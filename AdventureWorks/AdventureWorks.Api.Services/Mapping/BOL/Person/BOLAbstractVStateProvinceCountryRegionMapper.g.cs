using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractVStateProvinceCountryRegionMapper
	{
		public virtual BOVStateProvinceCountryRegion MapModelToBO(
			int stateProvinceID,
			ApiVStateProvinceCountryRegionRequestModel model
			)
		{
			BOVStateProvinceCountryRegion boVStateProvinceCountryRegion = new BOVStateProvinceCountryRegion();
			boVStateProvinceCountryRegion.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.CountryRegionName,
				model.IsOnlyStateProvinceFlag,
				model.StateProvinceCode,
				model.StateProvinceName,
				model.TerritoryID);
			return boVStateProvinceCountryRegion;
		}

		public virtual ApiVStateProvinceCountryRegionResponseModel MapBOToModel(
			BOVStateProvinceCountryRegion boVStateProvinceCountryRegion)
		{
			var model = new ApiVStateProvinceCountryRegionResponseModel();

			model.SetProperties(boVStateProvinceCountryRegion.StateProvinceID, boVStateProvinceCountryRegion.CountryRegionCode, boVStateProvinceCountryRegion.CountryRegionName, boVStateProvinceCountryRegion.IsOnlyStateProvinceFlag, boVStateProvinceCountryRegion.StateProvinceCode, boVStateProvinceCountryRegion.StateProvinceName, boVStateProvinceCountryRegion.TerritoryID);

			return model;
		}

		public virtual List<ApiVStateProvinceCountryRegionResponseModel> MapBOToModel(
			List<BOVStateProvinceCountryRegion> items)
		{
			List<ApiVStateProvinceCountryRegionResponseModel> response = new List<ApiVStateProvinceCountryRegionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7d27a19cc2aec8242ecd8ffb9d9e1929</Hash>
</Codenesium>*/