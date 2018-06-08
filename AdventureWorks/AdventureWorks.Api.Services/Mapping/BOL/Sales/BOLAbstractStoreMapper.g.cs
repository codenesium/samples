using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>5eac7e7be784a21cc7eb176ff4db0f23</Hash>
</Codenesium>*/