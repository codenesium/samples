using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCountryRegionMapper
	{
		public virtual DTOCountryRegion MapModelToDTO(
			string countryRegionCode,
			ApiCountryRegionRequestModel model
			)
		{
			DTOCountryRegion dtoCountryRegion = new DTOCountryRegion();

			dtoCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
			return dtoCountryRegion;
		}

		public virtual ApiCountryRegionResponseModel MapDTOToModel(
			DTOCountryRegion dtoCountryRegion)
		{
			if (dtoCountryRegion == null)
			{
				return null;
			}

			var model = new ApiCountryRegionResponseModel();

			model.SetProperties(dtoCountryRegion.CountryRegionCode, dtoCountryRegion.ModifiedDate, dtoCountryRegion.Name);

			return model;
		}

		public virtual List<ApiCountryRegionResponseModel> MapDTOToModel(
			List<DTOCountryRegion> dtos)
		{
			List<ApiCountryRegionResponseModel> response = new List<ApiCountryRegionResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae85c3d571d34e5ad98d20db9242f78c</Hash>
</Codenesium>*/