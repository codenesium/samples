using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStateProvinceMapper
	{
		public virtual DTOStateProvince MapModelToDTO(
			int stateProvinceID,
			ApiStateProvinceRequestModel model
			)
		{
			DTOStateProvince dtoStateProvince = new DTOStateProvince();

			dtoStateProvince.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceCode,
				model.TerritoryID);
			return dtoStateProvince;
		}

		public virtual ApiStateProvinceResponseModel MapDTOToModel(
			DTOStateProvince dtoStateProvince)
		{
			if (dtoStateProvince == null)
			{
				return null;
			}

			var model = new ApiStateProvinceResponseModel();

			model.SetProperties(dtoStateProvince.CountryRegionCode, dtoStateProvince.IsOnlyStateProvinceFlag, dtoStateProvince.ModifiedDate, dtoStateProvince.Name, dtoStateProvince.Rowguid, dtoStateProvince.StateProvinceCode, dtoStateProvince.StateProvinceID, dtoStateProvince.TerritoryID);

			return model;
		}

		public virtual List<ApiStateProvinceResponseModel> MapDTOToModel(
			List<DTOStateProvince> dtos)
		{
			List<ApiStateProvinceResponseModel> response = new List<ApiStateProvinceResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aabe87e83e362e58754e3a34f3fe3d75</Hash>
</Codenesium>*/