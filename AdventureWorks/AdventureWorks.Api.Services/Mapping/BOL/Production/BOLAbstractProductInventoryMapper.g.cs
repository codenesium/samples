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
    <Hash>446a6f3c6584c2c746c09f749d4dd805</Hash>
</Codenesium>*/