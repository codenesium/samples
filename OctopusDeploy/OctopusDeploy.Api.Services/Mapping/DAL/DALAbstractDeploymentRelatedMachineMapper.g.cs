using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractDeploymentRelatedMachineMapper
        {
                public virtual DeploymentRelatedMachine MapBOToEF(
                        BODeploymentRelatedMachine bo)
                {
                        DeploymentRelatedMachine efDeploymentRelatedMachine = new DeploymentRelatedMachine();

                        efDeploymentRelatedMachine.SetProperties(
                                bo.DeploymentId,
                                bo.Id,
                                bo.MachineId);
                        return efDeploymentRelatedMachine;
                }

                public virtual BODeploymentRelatedMachine MapEFToBO(
                        DeploymentRelatedMachine ef)
                {
                        var bo = new BODeploymentRelatedMachine();

                        bo.SetProperties(
                                ef.Id,
                                ef.DeploymentId,
                                ef.MachineId);
                        return bo;
                }

                public virtual List<BODeploymentRelatedMachine> MapEFToBO(
                        List<DeploymentRelatedMachine> records)
                {
                        List<BODeploymentRelatedMachine> response = new List<BODeploymentRelatedMachine>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>081b4d6ef82d250525499beef3f16623</Hash>
</Codenesium>*/