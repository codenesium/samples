using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractBusinessEntityMapper
        {
                public virtual BOBusinessEntity MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel model
                        )
                {
                        BOBusinessEntity boBusinessEntity = new BOBusinessEntity();

                        boBusinessEntity.SetProperties(
                                businessEntityID,
                                model.ModifiedDate,
                                model.Rowguid);
                        return boBusinessEntity;
                }

                public virtual ApiBusinessEntityResponseModel MapBOToModel(
                        BOBusinessEntity boBusinessEntity)
                {
                        var model = new ApiBusinessEntityResponseModel();

                        model.SetProperties(boBusinessEntity.BusinessEntityID, boBusinessEntity.ModifiedDate, boBusinessEntity.Rowguid);

                        return model;
                }

                public virtual List<ApiBusinessEntityResponseModel> MapBOToModel(
                        List<BOBusinessEntity> items)
                {
                        List<ApiBusinessEntityResponseModel> response = new List<ApiBusinessEntityResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>82d2bd52e04084d34ac5344c4b4a7144</Hash>
</Codenesium>*/