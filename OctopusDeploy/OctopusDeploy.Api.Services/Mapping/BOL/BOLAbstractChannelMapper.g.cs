using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractChannelMapper
        {
                public virtual BOChannel MapModelToBO(
                        string id,
                        ApiChannelRequestModel model
                        )
                {
                        BOChannel boChannel = new BOChannel();

                        boChannel.SetProperties(
                                id,
                                model.DataVersion,
                                model.JSON,
                                model.LifecycleId,
                                model.Name,
                                model.ProjectId,
                                model.TenantTags);
                        return boChannel;
                }

                public virtual ApiChannelResponseModel MapBOToModel(
                        BOChannel boChannel)
                {
                        var model = new ApiChannelResponseModel();

                        model.SetProperties(boChannel.DataVersion, boChannel.Id, boChannel.JSON, boChannel.LifecycleId, boChannel.Name, boChannel.ProjectId, boChannel.TenantTags);

                        return model;
                }

                public virtual List<ApiChannelResponseModel> MapBOToModel(
                        List<BOChannel> items)
                {
                        List<ApiChannelResponseModel> response = new List<ApiChannelResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>641d677fa2522326a2d2e6cba1643eb2</Hash>
</Codenesium>*/