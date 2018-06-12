using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOCertificate: AbstractBusinessObject
        {
                public BOCertificate() : base()
                {
                }

                public void SetProperties(string id,
                                          Nullable<DateTime> archived,
                                          DateTime created,
                                          byte[] dataVersion,
                                          string environmentIds,
                                          string jSON,
                                          string name,
                                          DateTime notAfter,
                                          string subject,
                                          string tenantIds,
                                          string tenantTags,
                                          string thumbprint)
                {
                        this.Archived = archived;
                        this.Created = created;
                        this.DataVersion = dataVersion;
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                public Nullable<DateTime> Archived { get; private set; }

                public DateTime Created { get; private set; }

                public byte[] DataVersion { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public DateTime NotAfter { get; private set; }

                public string Subject { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>35cbb9b2d2c592ebbc5d5ebf0bd5240b</Hash>
</Codenesium>*/