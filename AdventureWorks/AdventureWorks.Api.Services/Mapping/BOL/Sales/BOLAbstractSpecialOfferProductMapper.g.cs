using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c471b2a3c67907eea4988b8bd79e74de</Hash>
</Codenesium>*/