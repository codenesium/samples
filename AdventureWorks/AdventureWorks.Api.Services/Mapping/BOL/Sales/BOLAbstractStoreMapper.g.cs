using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractStoreMapper
        {
                public virtual BOStore MapModelToBO(
                        int businessEntityID,
                        ApiStoreRequestModel model
                        )
                {
                        BOStore boStore = new BOStore();
                        boStore.SetProperties(
                                businessEntityID,
                                model.Demographics,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid,
                                model.SalesPersonID);
                        return boStore;
                }

                public virtual ApiStoreResponseModel MapBOToModel(
                        BOStore boStore)
                {
                        var model = new ApiStoreResponseModel();

                        model.SetProperties(boStore.BusinessEntityID, boStore.Demographics, boStore.ModifiedDate, boStore.Name, boStore.Rowguid, boStore.SalesPersonID);

                        return model;
                }

                public virtual List<ApiStoreResponseModel> MapBOToModel(
                        List<BOStore> items)
                {
                        List<ApiStoreResponseModel> response = new List<ApiStoreResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4d56a7ff6e8cf6ca83f4209b68d2e275</Hash>
</Codenesium>*/