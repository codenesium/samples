using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALStateProvinceMapper
	{
		public virtual StateProvince MapModelToBO(
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

		public virtual ApiStateProvinceServerResponseModel MapBOToModel(
			StateProvince item)
		{
			var model = new ApiStateProvinceServerResponseModel();

			model.SetProperties(item.StateProvinceID, item.CountryRegionCode, item.IsOnlyStateProvinceFlag, item.ModifiedDate, item.Name, item.Rowguid, item.StateProvinceCode, item.TerritoryID);

			return model;
		}

		public virtual List<ApiStateProvinceServerResponseModel> MapBOToModel(
			List<StateProvince> items)
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
    <Hash>4ec921102114fb88db2ca23dc6c95209</Hash>
</Codenesium>*/