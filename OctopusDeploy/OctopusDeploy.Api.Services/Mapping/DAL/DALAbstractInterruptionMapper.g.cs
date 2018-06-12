using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractInterruptionMapper
        {
                public virtual Interruption MapBOToEF(
                        BOInterruption bo)
                {
                        Interruption efInterruption = new Interruption();

                        efInterruption.SetProperties(
                                bo.Created,
                                bo.EnvironmentId,
                                bo.Id,
                                bo.JSON,
                                bo.ProjectId,
                                bo.RelatedDocumentIds,
                                bo.ResponsibleTeamIds,
                                bo.Status,
                                bo.TaskId,
                                bo.TenantId,
                                bo.Title);
                        return efInterruption;
                }

                public virtual BOInterruption MapEFToBO(
                        Interruption ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOInterruption();

                        bo.SetProperties(
                                ef.Id,
                                ef.Created,
                                ef.EnvironmentId,
                                ef.JSON,
                                ef.ProjectId,
                                ef.RelatedDocumentIds,
                                ef.ResponsibleTeamIds,
                                ef.Status,
                                ef.TaskId,
                                ef.TenantId,
                                ef.Title);
                        return bo;
                }

                public virtual List<BOInterruption> MapEFToBO(
                        List<Interruption> records)
                {
                        List<BOInterruption> response = new List<BOInterruption>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>15d64d8776bf0b55f82c5b619a3ea7ab</Hash>
</Codenesium>*/