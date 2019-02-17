using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALStateProvinceMapper
	{
		public virtual StateProvince MapModelToEntity(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel model
			)
		{
			StateProvince item = new StateProvince();
			item.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceCode,
				model.TerritoryID);
			return item;
		}

		public virtual ApiStateProvinceServerResponseModel MapEntityToModel(
			StateProvince item)
		{
			var model = new ApiStateProvinceServerResponseModel();

			model.SetProperties(item.StateProvinceID,
			                    item.CountryRegionCode,
			                    item.IsOnlyStateProvinceFlag,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid,
			                    item.StateProvinceCode,
			                    item.TerritoryID);

			return model;
		}

		public virtual List<ApiStateProvinceServerResponseModel> MapEntityToModel(
			List<StateProvince> items)
		{
			List<ApiStateProvinceServerResponseModel> response = new List<ApiStateProvinceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>70c805909000986551e1358785cfd2f8</Hash>
</Codenesium>*/