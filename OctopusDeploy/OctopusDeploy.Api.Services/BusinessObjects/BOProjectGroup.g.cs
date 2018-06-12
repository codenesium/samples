using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOProjectGroup: AbstractBusinessObject
        {
                public BOProjectGroup() : base()
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
    <Hash>c82ffb4642b2aa4a6a476a8258cf02ff</Hash>
</Codenesium>*/