using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractServerTaskMapper
        {
                public virtual ServerTask MapBOToEF(
                        BOServerTask bo)
                {
                        ServerTask efServerTask = new ServerTask();

                        efServerTask.SetProperties(
                                bo.CompletedTime,
                                bo.ConcurrencyTag,
                                bo.Description,
                                bo.DurationSeconds,
                                bo.EnvironmentId,
                                bo.ErrorMessage,
                                bo.HasPendingInterruptions,
                                bo.HasWarningsOrErrors,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.ProjectId,
                                bo.QueueTime,
                                bo.ServerNodeId,
                                bo.StartTime,
                                bo.State,
                                bo.TenantId);
                        return efServerTask;
                }

                public virtual BOServerTask MapEFToBO(
                        ServerTask ef)
                {
                        var bo = new BOServerTask();

                        bo.SetProperties(
                                ef.Id,
                                ef.CompletedTime,
                                ef.ConcurrencyTag,
                                ef.Description,
                                ef.DurationSeconds,
                                ef.EnvironmentId,
                                ef.ErrorMessage,
                                ef.HasPendingInterruptions,
                                ef.HasWarningsOrErrors,
                                ef.JSON,
                                ef.Name,
                                ef.ProjectId,
                                ef.QueueTime,
                                ef.ServerNodeId,
                                ef.StartTime,
                                ef.State,
                                ef.TenantId);
                        return bo;
                }

                public virtual List<BOServerTask> MapEFToBO(
                        List<ServerTask> records)
                {
                        List<BOServerTask> response = new List<BOServerTask>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8212623c3207998042dff7b5e1e8fd57</Hash>
</Codenesium>*/