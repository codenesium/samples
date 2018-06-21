using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductInventoryMapper
        {
                public virtual BOProductInventory MapModelToBO(
                        int productID,
                        ApiProductInventoryRequestModel model
                        )
                {
                        BOProductInventory boProductInventory = new BOProductInventory();
                        boProductInventory.SetProperties(
                                productID,
                                model.Bin,
                                model.LocationID,
                                model.ModifiedDate,
                                model.Quantity,
                                model.Rowguid,
                                model.Shelf);
                        return boProductInventory;
                }

                public virtual ApiProductInventoryResponseModel MapBOToModel(
                        BOProductInventory boProductInventory)
                {
                        var model = new ApiProductInventoryResponseModel();

                        model.SetProperties(boProductInventory.Bin, boProductInventory.LocationID, boProductInventory.ModifiedDate, boProductInventory.ProductID, boProductInventory.Quantity, boProductInventory.Rowguid, boProductInventory.Shelf);

                        return model;
                }

                public virtual List<ApiProductInventoryResponseModel> MapBOToModel(
                        List<BOProductInventory> items)
                {
                        List<ApiProductInventoryResponseModel> response = new List<ApiProductInventoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c01d203885f445d329d4ce29d4ef6453</Hash>
</Codenesium>*/