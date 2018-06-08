using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductModelProductDescriptionCultureMapper
        {
                public virtual BOProductModelProductDescriptionCulture MapModelToBO(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel model
                        )
                {
                        BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture = new BOProductModelProductDescriptionCulture();

                        boProductModelProductDescriptionCulture.SetProperties(
                                productModelID,
                                model.CultureID,
                                model.ModifiedDate,
                                model.ProductDescriptionID);
                        return boProductModelProductDescriptionCulture;
                }

                public virtual ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
                        BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture)
                {
                        var model = new ApiProductModelProductDescriptionCultureResponseModel();

                        model.SetProperties(boProductModelProductDescriptionCulture.CultureID, boProductModelProductDescriptionCulture.ModifiedDate, boProductModelProductDescriptionCulture.ProductDescriptionID, boProductModelProductDescriptionCulture.ProductModelID);

                        return model;
                }

                public virtual List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
                        List<BOProductModelProductDescriptionCulture> items)
                {
                        List<ApiProductModelProductDescriptionCultureResponseModel> response = new List<ApiProductModelProductDescriptionCultureResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c60f2de1684447023ddb578347883eb0</Hash>
</Codenesium>*/