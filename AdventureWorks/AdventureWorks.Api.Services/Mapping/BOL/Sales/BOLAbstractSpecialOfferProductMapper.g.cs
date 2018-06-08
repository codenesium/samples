using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSpecialOfferProductMapper
        {
                public virtual BOSpecialOfferProduct MapModelToBO(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel model
                        )
                {
                        BOSpecialOfferProduct boSpecialOfferProduct = new BOSpecialOfferProduct();

                        boSpecialOfferProduct.SetProperties(
                                specialOfferID,
                                model.ModifiedDate,
                                model.ProductID,
                                model.Rowguid);
                        return boSpecialOfferProduct;
                }

                public virtual ApiSpecialOfferProductResponseModel MapBOToModel(
                        BOSpecialOfferProduct boSpecialOfferProduct)
                {
                        var model = new ApiSpecialOfferProductResponseModel();

                        model.SetProperties(boSpecialOfferProduct.ModifiedDate, boSpecialOfferProduct.ProductID, boSpecialOfferProduct.Rowguid, boSpecialOfferProduct.SpecialOfferID);

                        return model;
                }

                public virtual List<ApiSpecialOfferProductResponseModel> MapBOToModel(
                        List<BOSpecialOfferProduct> items)
                {
                        List<ApiSpecialOfferProductResponseModel> response = new List<ApiSpecialOfferProductResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6fdc87f06e639cb14baf6b8dbd2778a1</Hash>
</Codenesium>*/