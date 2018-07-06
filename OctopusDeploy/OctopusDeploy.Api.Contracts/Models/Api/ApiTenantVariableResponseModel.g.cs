using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantVariableResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string environmentId,
                        string jSON,
                        string ownerId,
                        string relatedDocumentId,
                        string tenantId,
                        string variableTemplateId)
                {
                        this.Id = id;
                        this.EnvironmentId = environmentId;
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
    <Hash>2705aa81333485f312f52d5f64a0572a</Hash>
</Codenesium>*/