using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractEventMapper
        {
                public virtual BOEvent MapModelToBO(
                        string id,
                        ApiEventRequestModel model
                        )
                {
                        BOEvent boEvent = new BOEvent();

                        boEvent.SetProperties(
                                id,
                                model.AutoId,
                                model.Category,
                                model.EnvironmentId,
                                model.JSON,
                                model.Message,
                                model.Occurred,
                                model.ProjectId,
                                model.RelatedDocumentIds,
                                model.TenantId,
                                model.UserId,
                                model.Username);
                        return boEvent;
                }

                public virtual ApiEventResponseModel MapBOToModel(
                        BOEvent boEvent)
                {
                        var model = new ApiEventResponseModel();

                        model.SetProperties(boEvent.AutoId, boEvent.Category, boEvent.EnvironmentId, boEvent.Id, boEvent.JSON, boEvent.Message, boEvent.Occurred, boEvent.ProjectId, boEvent.RelatedDocumentIds, boEvent.TenantId, boEvent.UserId, boEvent.Username);

                        return model;
                }

                public virtual List<ApiEventResponseModel> MapBOToModel(
                        List<BOEvent> items)
                {
                        List<ApiEventResponseModel> response = new List<ApiEventResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>fa4a446a2c42a995bf30aec7c41daf45</Hash>
</Codenesium>*/