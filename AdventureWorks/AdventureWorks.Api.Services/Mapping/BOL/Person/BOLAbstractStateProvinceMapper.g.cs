using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractStateProvinceMapper
	{
		public virtual BOStateProvince MapModelToBO(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel model
			)
		{
			BOStateProvince boStateProvince = new BOStateProvince();
			boStateProvince.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceCode,
				model.TerritoryID);
			return boStateProvince;
		}

		public virtual ApiStateProvinceServerResponseModel MapBOToModel(
			BOStateProvince boStateProvince)
		{
			var model = new ApiStateProvinceServerResponseModel();

			model.SetProperties(boStateProvince.StateProvinceID, boStateProvince.CountryRegionCode, boStateProvince.IsOnlyStateProvinceFlag, boStateProvince.ModifiedDate, boStateProvince.Name, boStateProvince.Rowguid, boStateProvince.StateProvinceCode, boStateProvince.TerritoryID);

			return model;
		}

		public virtual List<ApiStateProvinceServerResponseModel> MapBOToModel(
			List<BOStateProvince> items)
		{
			List<ApiStateProvinceServerResponseModel> response = new List<ApiStateProvinceServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7bad05cf7a3f8034e1e80840a796c72a</Hash>
</Codenesium>*/