using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiChannelRequestModel : AbstractApiRequestModel
        {
                public ApiChannelRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        byte[] dataVersion,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectId,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectId = projectId;
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

                private string lifecycleId;

                public string LifecycleId
                {
                        get
                        {
                                return this.lifecycleId.IsEmptyOrZeroOrNull() ? null : this.lifecycleId;
                        }

                        set
                        {
                                this.lifecycleId = value;
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

                private string projectId;

                [Required]
                public string ProjectId
                {
                        get
                        {
                                return this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
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
    <Hash>34cf623be1050f1a592bf5e590682ecd</Hash>
</Codenesium>*/