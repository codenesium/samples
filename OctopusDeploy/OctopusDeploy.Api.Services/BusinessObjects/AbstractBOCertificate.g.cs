using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOCertificate : AbstractBusinessObject
        {
                public AbstractBOCertificate()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  Nullable<DateTimeOffset> archived,
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

                public Nullable<DateTimeOffset> Archived { get; private set; }

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
    <Hash>e2c0c37d01e2a308a445a4fb16f03ab1</Hash>
</Codenesium>*/