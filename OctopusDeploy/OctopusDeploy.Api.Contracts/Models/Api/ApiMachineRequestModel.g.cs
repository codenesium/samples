using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachineRequestModel : AbstractApiRequestModel
        {
                public ApiMachineRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string communicationStyle,
                        string environmentIds,
                        string fingerprint,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string roles,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.CommunicationStyle = communicationStyle;
                        this.EnvironmentIds = environmentIds;
                        this.Fingerprint = fingerprint;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Roles = roles;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                private string communicationStyle;

                [Required]
                public string CommunicationStyle
                {
                        get
                        {
                                return this.communicationStyle;
                        }

                        set
                        {
                                this.communicationStyle = value;
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

                private string fingerprint;

                public string Fingerprint
                {
                        get
                        {
                                return this.fingerprint;
                        }

                        set
                        {
                                this.fingerprint = value;
                        }
                }

                private bool isDisabled;

                [Required]
                public bool IsDisabled
                {
                        get
                        {
                                return this.isDisabled;
                        }

                        set
                        {
                                this.isDisabled = value;
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

                private string machinePolicyId;

                public string MachinePolicyId
                {
                        get
                        {
                                return this.machinePolicyId;
                        }

                        set
                        {
                                this.machinePolicyId = value;
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

                private string relatedDocumentIds;

                public string RelatedDocumentIds
                {
                        get
                        {
                                return this.relatedDocumentIds;
                        }

                        set
                        {
                                this.relatedDocumentIds = value;
                        }
                }

                private string roles;

                [Required]
                public string Roles
                {
                        get
                        {
                                return this.roles;
                        }

                        set
                        {
                                this.roles = value;
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

                private string thumbprint;

                public string Thumbprint
                {
                        get
                        {
                                return this.thumbprint;
                        }

                        set
                        {
                                this.thumbprint = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d3dd14147795f94a1d597f403bb4764e</Hash>
</Codenesium>*/