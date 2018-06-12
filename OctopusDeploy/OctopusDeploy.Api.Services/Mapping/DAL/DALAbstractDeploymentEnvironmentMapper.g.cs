using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractDeploymentEnvironmentMapper
        {
                public virtual DeploymentEnvironment MapBOToEF(
                        BODeploymentEnvironment bo)
                {
                        DeploymentEnvironment efDeploymentEnvironment = new DeploymentEnvironment();

                        efDeploymentEnvironment.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.SortOrder);
                        return efDeploymentEnvironment;
                }

                public virtual BODeploymentEnvironment MapEFToBO(
                        DeploymentEnvironment ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BODeploymentEnvironment();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.Name,
                                ef.SortOrder);
                        return bo;
                }

                public virtual List<BODeploymentEnvironment> MapEFToBO(
                        List<DeploymentEnvironment> records)
                {
                        List<BODeploymentEnvironment> response = new List<BODeploymentEnvironment>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e3edf54fbd4bb274c6ecdb42dfecb97b</Hash>
</Codenesium>*/