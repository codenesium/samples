using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOTenantVariable: AbstractBusinessObject
        {
                public BOTenantVariable() : base()
                {
                }

                public void SetProperties(string id,
                                          string environmentId,
                                          string jSON,
                                          string ownerId,
                                          string relatedDocumentId,
                                          string tenantId,
                                          string variableTemplateId)
                {
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentId = relatedDocumentId;
                        this.TenantId = tenantId;
                        this.VariableTemplateId = variableTemplateId;
                }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string OwnerId { get; private set; }

                public string RelatedDocumentId { get; private set; }

                public string TenantId { get; private set; }

                public string VariableTemplateId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4c313b5905d28d24d360e1d40c1a4098</Hash>
</Codenesium>*/