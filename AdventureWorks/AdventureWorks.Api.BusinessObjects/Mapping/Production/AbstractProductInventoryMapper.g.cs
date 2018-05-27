using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductInventoryMapper
	{
		public virtual DTOProductInventory MapModelToDTO(
			int productID,
			ApiProductInventoryRequestModel model
			)
		{
			DTOProductInventory dtoProductInventory = new DTOProductInventory();

			dtoProductInventory.SetProperties(
				productID,
				model.Bin,
				model.LocationID,
				model.ModifiedDate,
				model.Quantity,
				model.Rowguid,
				model.Shelf);
			return dtoProductInventory;
		}

		public virtual ApiProductInventoryResponseModel MapDTOToModel(
			DTOProductInventory dtoProductInventory)
		{
			if (dtoProductInventory == null)
			{
				return null;
			}

			var model = new ApiProductInventoryResponseModel();

			model.SetProperties(dtoProductInventory.Bin, dtoProductInventory.LocationID, dtoProductInventory.ModifiedDate, dtoProductInventory.ProductID, dtoProductInventory.Quantity, dtoProductInventory.Rowguid, dtoProductInventory.Shelf);

			return model;
		}

		public virtual List<ApiProductInventoryResponseModel> MapDTOToModel(
			List<DTOProductInventory> dtos)
		{
			List<ApiProductInventoryResponseModel> response = new List<ApiProductInventoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>10d55467b9973ed363a14798da157653</Hash>
</Codenesium>*/