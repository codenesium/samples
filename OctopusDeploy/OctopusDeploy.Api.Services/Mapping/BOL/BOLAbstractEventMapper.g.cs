using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

                        model.SetProperties(boEvent.Id, boEvent.AutoId, boEvent.Category, boEvent.EnvironmentId, boEvent.JSON, boEvent.Message, boEvent.Occurred, boEvent.ProjectId, boEvent.RelatedDocumentIds, boEvent.TenantId, boEvent.UserId, boEvent.Username);

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
    <Hash>7c6663795326272033fde6fbc7a1cebd</Hash>
</Codenesium>*/