using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractDeploymentProcessMapper
        {
                public virtual DeploymentProcess MapBOToEF(
                        BODeploymentProcess bo)
                {
                        DeploymentProcess efDeploymentProcess = new DeploymentProcess();

                        efDeploymentProcess.SetProperties(
                                bo.Id,
                                bo.IsFrozen,
                                bo.JSON,
                                bo.OwnerId,
                                bo.RelatedDocumentIds,
                                bo.Version);
                        return efDeploymentProcess;
                }

                public virtual BODeploymentProcess MapEFToBO(
                        DeploymentProcess ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BODeploymentProcess();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsFrozen,
                                ef.JSON,
                                ef.OwnerId,
                                ef.RelatedDocumentIds,
                                ef.Version);
                        return bo;
                }

                public virtual List<BODeploymentProcess> MapEFToBO(
                        List<DeploymentProcess> records)
                {
                        List<BODeploymentProcess> response = new List<BODeploymentProcess>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>73f1df2d6092edf83a2e0841204a5a3b</Hash>
</Codenesium>*/