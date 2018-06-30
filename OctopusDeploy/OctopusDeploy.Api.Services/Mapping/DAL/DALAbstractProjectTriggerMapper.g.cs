using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractProjectTriggerMapper
        {
                public virtual ProjectTrigger MapBOToEF(
                        BOProjectTrigger bo)
                {
                        ProjectTrigger efProjectTrigger = new ProjectTrigger();
                        efProjectTrigger.SetProperties(
                                bo.Id,
                                bo.IsDisabled,
                                bo.JSON,
                                bo.Name,
                                bo.ProjectId,
                                bo.TriggerType);
                        return efProjectTrigger;
                }

                public virtual BOProjectTrigger MapEFToBO(
                        ProjectTrigger ef)
                {
                        var bo = new BOProjectTrigger();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsDisabled,
                                ef.JSON,
                                ef.Name,
                                ef.ProjectId,
                                ef.TriggerType);
                        return bo;
                }

                public virtual List<BOProjectTrigger> MapEFToBO(
                        List<ProjectTrigger> records)
                {
                        List<BOProjectTrigger> response = new List<BOProjectTrigger>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2f4abf658dfe4376d572a37d67cded5d</Hash>
</Codenesium>*/