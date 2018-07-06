using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCertificateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        DateTimeOffset? archived,
                        DateTimeOffset created,
                        byte[] dataVersion,
                        string environmentIds,
                        string jSON,
                        string name,
                        DateTimeOffset notAfter,
                        string subject,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.Id = id;
                        this.Archived = archived;
                        this.Created = created;
                        this.DataVersion = dataVersion;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                public DateTimeOffset? Archived { get; private set; }

                public DateTimeOffset Created { get; private set; }

                public byte[] DataVersion { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public DateTimeOffset NotAfter { get; private set; }

                public string Subject { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9929b17cd1618958757933739982cfb1</Hash>
</Codenesium>*/