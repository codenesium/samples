using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBODeploymentEnvironment: AbstractBusinessObject
        {
                public AbstractBODeploymentEnvironment() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  byte[] dataVersion,
                                                  string jSON,
                                                  string name,
                                                  int sortOrder)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8f8082ad3fcd39b9790182b808a8b7d2</Hash>
</Codenesium>*/