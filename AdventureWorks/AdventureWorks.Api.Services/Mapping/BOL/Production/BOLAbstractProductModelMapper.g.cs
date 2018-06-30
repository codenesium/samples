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
                                model.Instructions,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid);
                        return boProductModel;
                }

                public virtual ApiProductModelResponseModel MapBOToModel(
                        BOProductModel boProductModel)
                {
                        var model = new ApiProductModelResponseModel();

                        model.SetProperties(boProductModel.ProductModelID, boProductModel.CatalogDescription, boProductModel.Instructions, boProductModel.ModifiedDate, boProductModel.Name, boProductModel.Rowguid);

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
    <Hash>0f0356f8fa54dbe350e4702c310f16e9</Hash>
</Codenesium>*/