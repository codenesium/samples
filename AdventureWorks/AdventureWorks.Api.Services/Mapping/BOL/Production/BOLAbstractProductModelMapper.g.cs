using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductModelMapper
        {
                public virtual BOProductModel MapModelToBO(
                        int productModelID,
                        ApiProductModelRequestModel model
                        )
                {
                        BOProductModel boProductModel = new BOProductModel();
                        boProductModel.SetProperties(
                                productModelID,
                                model.CatalogDescription,
                                model.Instruction,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid);
                        return boProductModel;
                }

                public virtual ApiProductModelResponseModel MapBOToModel(
                        BOProductModel boProductModel)
                {
                        var model = new ApiProductModelResponseModel();

                        model.SetProperties(boProductModel.ProductModelID, boProductModel.CatalogDescription, boProductModel.Instruction, boProductModel.ModifiedDate, boProductModel.Name, boProductModel.Rowguid);

                        return model;
                }

                public virtual List<ApiProductModelResponseModel> MapBOToModel(
                        List<BOProductModel> items)
                {
                        List<ApiProductModelResponseModel> response = new List<ApiProductModelResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>29bbdf90371dff337a9522b136b80362</Hash>
</Codenesium>*/