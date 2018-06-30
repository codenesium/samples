using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9d75471602c8acfa6a4a7eab855e994a</Hash>
</Codenesium>*/