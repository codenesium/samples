using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1eee1c9a11143187a3b004a3ed6be1d5</Hash>
</Codenesium>*/