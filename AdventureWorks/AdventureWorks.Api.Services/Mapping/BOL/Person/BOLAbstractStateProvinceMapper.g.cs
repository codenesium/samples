using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractStateProvinceMapper
	{
		public virtual BOStateProvince MapModelToBO(
			int stateProvinceID,
			ApiStateProvinceRequestModel model
			)
		{
			BOStateProvince BOStateProvince = new BOStateProvince();

			BOStateProvince.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceCode,
				model.TerritoryID);
			return BOStateProvince;
		}

		public virtual ApiStateProvinceResponseModel MapBOToModel(
			BOStateProvince BOStateProvince)
		{
			if (BOStateProvince == null)
			{
				return null;
			}

			var model = new ApiStateProvinceResponseModel();

			model.SetProperties(BOStateProvince.CountryRegionCode, BOStateProvince.IsOnlyStateProvinceFlag, BOStateProvince.ModifiedDate, BOStateProvince.Name, BOStateProvince.Rowguid, BOStateProvince.StateProvinceCode, BOStateProvince.StateProvinceID, BOStateProvince.TerritoryID);

			return model;
		}

		public virtual List<ApiStateProvinceResponseModel> MapBOToModel(
			List<BOStateProvince> BOs)
		{
			List<ApiStateProvinceResponseModel> response = new List<ApiStateProvinceResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>12e105a829e04ab84f711f081ebf775a</Hash>
</Codenesium>*/