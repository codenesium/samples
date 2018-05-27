using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLocationMapper
	{
		public virtual DTOLocation MapModelToDTO(
			short locationID,
			ApiLocationRequestModel model
			)
		{
			DTOLocation dtoLocation = new DTOLocation();

			dtoLocation.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
			return dtoLocation;
		}

		public virtual ApiLocationResponseModel MapDTOToModel(
			DTOLocation dtoLocation)
		{
			if (dtoLocation == null)
			{
				return null;
			}

			var model = new ApiLocationResponseModel();

			model.SetProperties(dtoLocation.Availability, dtoLocation.CostRate, dtoLocation.LocationID, dtoLocation.ModifiedDate, dtoLocation.Name);

			return model;
		}

		public virtual List<ApiLocationResponseModel> MapDTOToModel(
			List<DTOLocation> dtos)
		{
			List<ApiLocationResponseModel> response = new List<ApiLocationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2dc70da4a5cd1c37c132836cdca08cf1</Hash>
</Codenesium>*/