using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractAccountMapper
        {
                public virtual Account MapBOToEF(
                        BOAccount bo)
                {
                        Account efAccount = new Account();

                        efAccount.SetProperties(
                                bo.AccountType,
                                bo.EnvironmentIds,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.TenantIds,
                                bo.TenantTags);
                        return efAccount;
                }

                public virtual BOAccount MapEFToBO(
                        Account ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOAccount();

                        bo.SetProperties(
                                ef.Id,
                                ef.AccountType,
                                ef.EnvironmentIds,
                                ef.JSON,
                                ef.Name,
                                ef.TenantIds,
                                ef.TenantTags);
                        return bo;
                }

                public virtual List<BOAccount> MapEFToBO(
                        List<Account> records)
                {
                        List<BOAccount> response = new List<BOAccount>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>af3ebb066e7f43b24dfd18c54e2bd007</Hash>
</Codenesium>*/