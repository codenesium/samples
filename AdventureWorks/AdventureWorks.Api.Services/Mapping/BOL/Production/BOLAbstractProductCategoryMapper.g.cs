using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductCategoryMapper
        {
                public virtual BOProductCategory MapModelToBO(
                        int productCategoryID,
                        ApiProductCategoryRequestModel model
                        )
                {
                        BOProductCategory boProductCategory = new BOProductCategory();
                        boProductCategory.SetProperties(
                                productCategoryID,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid);
                        return boProductCategory;
                }

                public virtual ApiProductCategoryResponseModel MapBOToModel(
                        BOProductCategory boProductCategory)
                {
                        var model = new ApiProductCategoryResponseModel();

                        model.SetProperties(boProductCategory.ProductCategoryID, boProductCategory.ModifiedDate, boProductCategory.Name, boProductCategory.Rowguid);

                        return model;
                }

                public virtual List<ApiProductCategoryResponseModel> MapBOToModel(
                        List<BOProductCategory> items)
                {
                        List<ApiProductCategoryResponseModel> response = new List<ApiProductCategoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6545616b96f35b6d094b455b2ce2a9a6</Hash>
</Codenesium>*/