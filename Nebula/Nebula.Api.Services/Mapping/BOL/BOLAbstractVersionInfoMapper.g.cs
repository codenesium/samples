using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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

                        model.SetProperties(boVersionInfo.AppliedOn, boVersionInfo.Description, boVersionInfo.Version);

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
    <Hash>758b077341f46b0a7b3aa4e96abdfbde</Hash>
</Codenesium>*/