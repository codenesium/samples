using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCountryRegionMapper
	{
		public virtual BOCountryRegion MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionRequestModel model
			)
		{
			BOCountryRegion BOCountryRegion = new BOCountryRegion();

			BOCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
			return BOCountryRegion;
		}

		public virtual ApiCountryRegionResponseModel MapBOToModel(
			BOCountryRegion BOCountryRegion)
		{
			if (BOCountryRegion == null)
			{
				return null;
			}

			var model = new ApiCountryRegionResponseModel();

			model.SetProperties(BOCountryRegion.CountryRegionCode, BOCountryRegion.ModifiedDate, BOCountryRegion.Name);

			return model;
		}

		public virtual List<ApiCountryRegionResponseModel> MapBOToModel(
			List<BOCountryRegion> BOs)
		{
			List<ApiCountryRegionResponseModel> response = new List<ApiCountryRegionResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>46a000dcc34fcdaa8f5f6d6e197ade57</Hash>
</Codenesium>*/