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

                        model.SetProperties(boProductDescription.ProductDescriptionID, boProductDescription.Description, boProductDescription.ModifiedDate, boProductDescription.Rowguid);

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
    <Hash>11bfff88d43770ebf01c2e02a2f3d656</Hash>
</Codenesium>*/