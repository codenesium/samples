using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractEventMapper
        {
                public virtual Event MapBOToEF(
                        BOEvent bo)
                {
                        Event efEvent = new Event();

                        efEvent.SetProperties(
                                bo.AutoId,
                                bo.Category,
                                bo.EnvironmentId,
                                bo.Id,
                                bo.JSON,
                                bo.Message,
                                bo.Occurred,
                                bo.ProjectId,
                                bo.RelatedDocumentIds,
                                bo.TenantId,
                                bo.UserId,
                                bo.Username);
                        return efEvent;
                }

                public virtual BOEvent MapEFToBO(
                        Event ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOEvent();

                        bo.SetProperties(
                                ef.Id,
                                ef.AutoId,
                                ef.Category,
                                ef.EnvironmentId,
                                ef.JSON,
                                ef.Message,
                                ef.Occurred,
                                ef.ProjectId,
                                ef.RelatedDocumentIds,
                                ef.TenantId,
                                ef.UserId,
                                ef.Username);
                        return bo;
                }

                public virtual List<BOEvent> MapEFToBO(
                        List<Event> records)
                {
                        List<BOEvent> response = new List<BOEvent>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b611c6fc71e401ed240a9cc4dd49fd44</Hash>
</Codenesium>*/