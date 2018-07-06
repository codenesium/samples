using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiAccountResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string accountType,
                        string environmentIds,
                        string jSON,
                        string name,
                        string tenantIds,
                        string tenantTags)
                {
                        this.Id = id;
                        this.AccountType = accountType;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                public string AccountType { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8b24856e447a4871abcafaeb4dea9532</Hash>
</Codenesium>*/