using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantVariableRequestModel: AbstractApiRequestModel
        {
                public ApiTenantVariableRequestModel() : base()
                {
                }

                public void SetProperties(
                        string environmentId,
                        string jSON,
                        string ownerId,
                        string relatedDocumentId,
                        string tenantId,
                        string variableTemplateId)
                {
                        this.EnvironmentId = environmentId;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentId = relatedDocumentId;
                        this.TenantId = tenantId;
                        this.VariableTemplateId = variableTemplateId;
                }

                private string environmentId;

                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId.IsEmptyOrZeroOrNull() ? null : this.environmentId;
                        }

                        set
                        {
                                this.environmentId = value;
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

                private string ownerId;

                [Required]
                public string OwnerId
                {
                        get
                        {
                                return this.ownerId;
                        }

                        set
                        {
                                this.ownerId = value;
                        }
                }

                private string relatedDocumentId;

                public string RelatedDocumentId
                {
                        get
                        {
                                return this.relatedDocumentId.IsEmptyOrZeroOrNull() ? null : this.relatedDocumentId;
                        }

                        set
                        {
                                this.relatedDocumentId = value;
                        }
                }

                private string tenantId;

                [Required]
                public string TenantId
                {
                        get
                        {
                                return this.tenantId;
                        }

                        set
                        {
                                this.tenantId = value;
                        }
                }

                private string variableTemplateId;

                [Required]
                public string VariableTemplateId
                {
                        get
                        {
                                return this.variableTemplateId;
                        }

                        set
                        {
                                this.variableTemplateId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5b751edcb53d559f61ee91399e23de54</Hash>
</Codenesium>*/