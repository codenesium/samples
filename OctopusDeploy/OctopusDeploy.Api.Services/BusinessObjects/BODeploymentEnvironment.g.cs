using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BODeploymentEnvironment: AbstractBusinessObject
        {
                public BODeploymentEnvironment() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>d14b6da38e58af090981211cbdac9b1b</Hash>
</Codenesium>*/