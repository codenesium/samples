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
    <Hash>db30181a07cf11d5221fb183890a1312</Hash>
</Codenesium>*/