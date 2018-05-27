using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLShipMethodMapper
	{
		public virtual DTOShipMethod MapModelToDTO(
			int shipMethodID,
			ApiShipMethodRequestModel model
			)
		{
			DTOShipMethod dtoShipMethod = new DTOShipMethod();

			dtoShipMethod.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
			return dtoShipMethod;
		}

		public virtual ApiShipMethodResponseModel MapDTOToModel(
			DTOShipMethod dtoShipMethod)
		{
			if (dtoShipMethod == null)
			{
				return null;
			}

			var model = new ApiShipMethodResponseModel();

			model.SetProperties(dtoShipMethod.ModifiedDate, dtoShipMethod.Name, dtoShipMethod.Rowguid, dtoShipMethod.ShipBase, dtoShipMethod.ShipMethodID, dtoShipMethod.ShipRate);

			return model;
		}

		public virtual List<ApiShipMethodResponseModel> MapDTOToModel(
			List<DTOShipMethod> dtos)
		{
			List<ApiShipMethodResponseModel> response = new List<ApiShipMethodResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>915c6ee5b56c647324877a3e5083b782</Hash>
</Codenesium>*/