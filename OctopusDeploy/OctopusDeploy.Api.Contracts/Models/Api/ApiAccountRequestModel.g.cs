using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiAccountRequestModel : AbstractApiRequestModel
        {
                public ApiAccountRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string accountType,
                        string environmentIds,
                        string jSON,
                        string name,
                        string tenantIds,
                        string tenantTags)
                {
                        this.AccountType = accountType;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                private string accountType;

                [Required]
                public string AccountType
                {
                        get
                        {
                                return this.accountType;
                        }

                        set
                        {
                                this.accountType = value;
                        }
                }

                private string environmentIds;

                [Required]
                public string EnvironmentIds
                {
                        get
                        {
                                return this.environmentIds;
                        }

                        set
                        {
                                this.environmentIds = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string tenantIds;

                public string TenantIds
                {
                        get
                        {
                                return this.tenantIds.IsEmptyOrZeroOrNull() ? null : this.tenantIds;
                        }

                        set
                        {
                                this.tenantIds = value;
                        }
                }

                private string tenantTags;

                public string TenantTags
                {
                        get
                        {
                                return this.tenantTags.IsEmptyOrZeroOrNull() ? null : this.tenantTags;
                        }

                        set
                        {
                                this.tenantTags = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>33f4ba1d14170aad65957fbce8d0123b</Hash>
</Codenesium>*/