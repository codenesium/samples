using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantRequestModel: AbstractApiRequestModel
        {
                public ApiTenantRequestModel() : base()
                {
                }

                public void SetProperties(
                        byte[] dataVersion,
                        string jSON,
                        string name,
                        string projectIds,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectIds = projectIds;
                        this.TenantTags = tenantTags;
                }

                private byte[] dataVersion;

                [Required]
                public byte[] DataVersion
                {
                        get
                        {
                                return this.dataVersion;
                        }

                        set
                        {
                                this.dataVersion = value;
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

                private string projectIds;

                [Required]
                public string ProjectIds
                {
                        get
                        {
                                return this.projectIds;
                        }

                        set
                        {
                                this.projectIds = value;
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
    <Hash>27efcf9b836482010fa624c863f6e1f7</Hash>
</Codenesium>*/