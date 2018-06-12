using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractMachineMapper
        {
                public virtual Machine MapBOToEF(
                        BOMachine bo)
                {
                        Machine efMachine = new Machine();

                        efMachine.SetProperties(
                                bo.CommunicationStyle,
                                bo.EnvironmentIds,
                                bo.Fingerprint,
                                bo.Id,
                                bo.IsDisabled,
                                bo.JSON,
                                bo.MachinePolicyId,
                                bo.Name,
                                bo.RelatedDocumentIds,
                                bo.Roles,
                                bo.TenantIds,
                                bo.TenantTags,
                                bo.Thumbprint);
                        return efMachine;
                }

                public virtual BOMachine MapEFToBO(
                        Machine ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOMachine();

                        bo.SetProperties(
                                ef.Id,
                                ef.CommunicationStyle,
                                ef.EnvironmentIds,
                                ef.Fingerprint,
                                ef.IsDisabled,
                                ef.JSON,
                                ef.MachinePolicyId,
                                ef.Name,
                                ef.RelatedDocumentIds,
                                ef.Roles,
                                ef.TenantIds,
                                ef.TenantTags,
                                ef.Thumbprint);
                        return bo;
                }

                public virtual List<BOMachine> MapEFToBO(
                        List<Machine> records)
                {
                        List<BOMachine> response = new List<BOMachine>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7256414e22a4b87e018dae6ae0868f65</Hash>
</Codenesium>*/