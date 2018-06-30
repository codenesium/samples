using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTeamRequestModel : AbstractApiRequestModel
        {
                public ApiTeamRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string environmentIds,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
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

                private string memberUserIds;

                [Required]
                public string MemberUserIds
                {
                        get
                        {
                                return this.memberUserIds;
                        }

                        set
                        {
                                this.memberUserIds = value;
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

                private string projectGroupIds;

                public string ProjectGroupIds
                {
                        get
                        {
                                return this.projectGroupIds;
                        }

                        set
                        {
                                this.projectGroupIds = value;
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

                private string tenantIds;

                public string TenantIds
                {
                        get
                        {
                                return this.tenantIds;
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
                                return this.tenantTags;
                        }

                        set
                        {
                                this.tenantTags = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3e5f4cc81f20134a5c51ab28016305e8</Hash>
</Codenesium>*/