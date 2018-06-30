using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractVersionInfoMapper
        {
                public virtual BOVersionInfo MapModelToBO(
                        long version,
                        ApiVersionInfoRequestModel model
                        )
                {
                        BOVersionInfo boVersionInfo = new BOVersionInfo();
                        boVersionInfo.SetProperties(
                                version,
                                model.AppliedOn,
                                model.Description);
                        return boVersionInfo;
                }

                public virtual ApiVersionInfoResponseModel MapBOToModel(
                        BOVersionInfo boVersionInfo)
                {
                        var model = new ApiVersionInfoResponseModel();

                        model.SetProperties(boVersionInfo.Version, boVersionInfo.AppliedOn, boVersionInfo.Description);

                        return model;
                }

                public virtual List<ApiVersionInfoResponseModel> MapBOToModel(
                        List<BOVersionInfo> items)
                {
                        List<ApiVersionInfoResponseModel> response = new List<ApiVersionInfoResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>237211b305780f38688c52d76a0a2015</Hash>
</Codenesium>*/