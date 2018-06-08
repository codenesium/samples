using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractLinkStatusMapper
        {
                public virtual BOLinkStatus MapModelToBO(
                        int id,
                        ApiLinkStatusRequestModel model
                        )
                {
                        BOLinkStatus boLinkStatus = new BOLinkStatus();

                        boLinkStatus.SetProperties(
                                id,
                                model.Name);
                        return boLinkStatus;
                }

                public virtual ApiLinkStatusResponseModel MapBOToModel(
                        BOLinkStatus boLinkStatus)
                {
                        var model = new ApiLinkStatusResponseModel();

                        model.SetProperties(boLinkStatus.Id, boLinkStatus.Name);

                        return model;
                }

                public virtual List<ApiLinkStatusResponseModel> MapBOToModel(
                        List<BOLinkStatus> items)
                {
                        List<ApiLinkStatusResponseModel> response = new List<ApiLinkStatusResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>338ca93a8463685b24d3c972e94701bb</Hash>
</Codenesium>*/