using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductVendorMapper
        {
                public virtual BOProductVendor MapModelToBO(
                        int productID,
                        ApiProductVendorRequestModel model
                        )
                {
                        BOProductVendor boProductVendor = new BOProductVendor();

                        boProductVendor.SetProperties(
                                productID,
                                model.AverageLeadTime,
                                model.BusinessEntityID,
                                model.LastReceiptCost,
                                model.LastReceiptDate,
                                model.MaxOrderQty,
                                model.MinOrderQty,
                                model.ModifiedDate,
                                model.OnOrderQty,
                                model.StandardPrice,
                                model.UnitMeasureCode);
                        return boProductVendor;
                }

                public virtual ApiProductVendorResponseModel MapBOToModel(
                        BOProductVendor boProductVendor)
                {
                        var model = new ApiProductVendorResponseModel();

                        model.SetProperties(boProductVendor.AverageLeadTime, boProductVendor.BusinessEntityID, boProductVendor.LastReceiptCost, boProductVendor.LastReceiptDate, boProductVendor.MaxOrderQty, boProductVendor.MinOrderQty, boProductVendor.ModifiedDate, boProductVendor.OnOrderQty, boProductVendor.ProductID, boProductVendor.StandardPrice, boProductVendor.UnitMeasureCode);

                        return model;
                }

                public virtual List<ApiProductVendorResponseModel> MapBOToModel(
                        List<BOProductVendor> items)
                {
                        List<ApiProductVendorResponseModel> response = new List<ApiProductVendorResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b3f8c71c4aa3ac29a09f0e7db04e0142</Hash>
</Codenesium>*/