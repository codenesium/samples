using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractTenantMapper
        {
                public virtual Tenant MapBOToEF(
                        BOTenant bo)
                {
                        Tenant efTenant = new Tenant();

                        efTenant.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.ProjectIds,
                                bo.TenantTags);
                        return efTenant;
                }

                public virtual BOTenant MapEFToBO(
                        Tenant ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTenant();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.Name,
                                ef.ProjectIds,
                                ef.TenantTags);
                        return bo;
                }

                public virtual List<BOTenant> MapEFToBO(
                        List<Tenant> records)
                {
                        List<BOTenant> response = new List<BOTenant>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f7a865d102c0e175e1be9d94e790d7c3</Hash>
</Codenesium>*/