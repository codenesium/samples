using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class BOLAbstractRowVersionCheckMapper
        {
                public virtual BORowVersionCheck MapModelToBO(
                        int id,
                        ApiRowVersionCheckRequestModel model
                        )
                {
                        BORowVersionCheck boRowVersionCheck = new BORowVersionCheck();
                        boRowVersionCheck.SetProperties(
                                id,
                                model.Name,
                                model.RowVersion);
                        return boRowVersionCheck;
                }

                public virtual ApiRowVersionCheckResponseModel MapBOToModel(
                        BORowVersionCheck boRowVersionCheck)
                {
                        var model = new ApiRowVersionCheckResponseModel();

                        model.SetProperties(boRowVersionCheck.Id, boRowVersionCheck.Name, boRowVersionCheck.RowVersion);

                        return model;
                }

                public virtual List<ApiRowVersionCheckResponseModel> MapBOToModel(
                        List<BORowVersionCheck> items)
                {
                        List<ApiRowVersionCheckResponseModel> response = new List<ApiRowVersionCheckResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>28d0f86f47045ff7f708120521816300</Hash>
</Codenesium>*/