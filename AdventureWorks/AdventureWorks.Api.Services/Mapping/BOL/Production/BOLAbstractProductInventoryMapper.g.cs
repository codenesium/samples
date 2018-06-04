using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductInventoryMapper
	{
		public virtual BOProductInventory MapModelToBO(
			int productID,
			ApiProductInventoryRequestModel model
			)
		{
			BOProductInventory BOProductInventory = new BOProductInventory();

			BOProductInventory.SetProperties(
				productID,
				model.Bin,
				model.LocationID,
				model.ModifiedDate,
				model.Quantity,
				model.Rowguid,
				model.Shelf);
			return BOProductInventory;
		}

		public virtual ApiProductInventoryResponseModel MapBOToModel(
			BOProductInventory BOProductInventory)
		{
			if (BOProductInventory == null)
			{
				return null;
			}

			var model = new ApiProductInventoryResponseModel();

			model.SetProperties(BOProductInventory.Bin, BOProductInventory.LocationID, BOProductInventory.ModifiedDate, BOProductInventory.ProductID, BOProductInventory.Quantity, BOProductInventory.Rowguid, BOProductInventory.Shelf);

			return model;
		}

		public virtual List<ApiProductInventoryResponseModel> MapBOToModel(
			List<BOProductInventory> BOs)
		{
			List<ApiProductInventoryResponseModel> response = new List<ApiProductInventoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea0bce024d9cb515b8592f7597d096de</Hash>
</Codenesium>*/