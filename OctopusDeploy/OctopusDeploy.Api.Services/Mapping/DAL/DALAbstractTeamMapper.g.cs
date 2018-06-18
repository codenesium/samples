using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractTeamMapper
        {
                public virtual Team MapBOToEF(
                        BOTeam bo)
                {
                        Team efTeam = new Team();

                        efTeam.SetProperties(
                                bo.EnvironmentIds,
                                bo.Id,
                                bo.JSON,
                                bo.MemberUserIds,
                                bo.Name,
                                bo.ProjectGroupIds,
                                bo.ProjectIds,
                                bo.TenantIds,
                                bo.TenantTags);
                        return efTeam;
                }

                public virtual BOTeam MapEFToBO(
                        Team ef)
                {
                        var bo = new BOTeam();

                        bo.SetProperties(
                                ef.Id,
                                ef.EnvironmentIds,
                                ef.JSON,
                                ef.MemberUserIds,
                                ef.Name,
                                ef.ProjectGroupIds,
                                ef.ProjectIds,
                                ef.TenantIds,
                                ef.TenantTags);
                        return bo;
                }

                public virtual List<BOTeam> MapEFToBO(
                        List<Team> records)
                {
                        List<BOTeam> response = new List<BOTeam>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2e02f136ab93402a3080de8a61ac8cce</Hash>
</Codenesium>*/