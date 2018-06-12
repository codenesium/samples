using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOLifecycle: AbstractBusinessObject
        {
                public BOLifecycle() : base()
                {
                }

                public void SetProperties(string id,
                                          byte[] dataVersion,
                                          string jSON,
                                          string name)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b3e36d9c572054327e4abd7a1b1eb94b</Hash>
</Codenesium>*/