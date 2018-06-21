using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductDescriptionMapper
        {
                public virtual BOProductDescription MapModelToBO(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel model
                        )
                {
                        BOProductDescription boProductDescription = new BOProductDescription();
                        boProductDescription.SetProperties(
                                productDescriptionID,
                                model.Description,
                                model.ModifiedDate,
                                model.Rowguid);
                        return boProductDescription;
                }

                public virtual ApiProductDescriptionResponseModel MapBOToModel(
                        BOProductDescription boProductDescription)
                {
                        var model = new ApiProductDescriptionResponseModel();

                        model.SetProperties(boProductDescription.Description, boProductDescription.ModifiedDate, boProductDescription.ProductDescriptionID, boProductDescription.Rowguid);

                        return model;
                }

                public virtual List<ApiProductDescriptionResponseModel> MapBOToModel(
                        List<BOProductDescription> items)
                {
                        List<ApiProductDescriptionResponseModel> response = new List<ApiProductDescriptionResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9107d35ce0a52e5365e946f8e1f3169f</Hash>
</Codenesium>*/