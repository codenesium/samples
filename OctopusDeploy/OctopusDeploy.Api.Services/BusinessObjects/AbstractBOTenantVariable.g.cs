using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOTenantVariable: AbstractBusinessObject
        {
                public AbstractBOTenantVariable() : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>f2865bcbea07003bb23b24e08acc2c89</Hash>
</Codenesium>*/