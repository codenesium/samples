using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractServerTaskMapper
        {
                public virtual BOServerTask MapModelToBO(
                        string id,
                        ApiServerTaskRequestModel model
                        )
                {
                        BOServerTask boServerTask = new BOServerTask();

                        boServerTask.SetProperties(
                                id,
                                model.CompletedTime,
                                model.ConcurrencyTag,
                                model.Description,
                                model.DurationSeconds,
                                model.EnvironmentId,
                                model.ErrorMessage,
                                model.HasPendingInterruptions,
                                model.HasWarningsOrErrors,
                                model.JSON,
                                model.Name,
                                model.ProjectId,
                                model.QueueTime,
                                model.ServerNodeId,
                                model.StartTime,
                                model.State,
                                model.TenantId);
                        return boServerTask;
                }

                public virtual ApiServerTaskResponseModel MapBOToModel(
                        BOServerTask boServerTask)
                {
                        var model = new ApiServerTaskResponseModel();

                        model.SetProperties(boServerTask.CompletedTime, boServerTask.ConcurrencyTag, boServerTask.Description, boServerTask.DurationSeconds, boServerTask.EnvironmentId, boServerTask.ErrorMessage, boServerTask.HasPendingInterruptions, boServerTask.HasWarningsOrErrors, boServerTask.Id, boServerTask.JSON, boServerTask.Name, boServerTask.ProjectId, boServerTask.QueueTime, boServerTask.ServerNodeId, boServerTask.StartTime, boServerTask.State, boServerTask.TenantId);

                        return model;
                }

                public virtual List<ApiServerTaskResponseModel> MapBOToModel(
                        List<BOServerTask> items)
                {
                        List<ApiServerTaskResponseModel> response = new List<ApiServerTaskResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b4883f1a691987fb9307164cf2a6a86e</Hash>
</Codenesium>*/