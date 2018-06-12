using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOMutex: AbstractBusinessObject
        {
                public BOMutex() : base()
                {
                }

                public void SetProperties(string id,
                                          string jSON)
                {
                        this.Id = id;
                        this.JSON = jSON;
                }

                public string Id { get; private set; }

                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7a982537fcd38a2b50a0446cdab8373b</Hash>
</Codenesium>*/