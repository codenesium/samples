using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOConfiguration: AbstractBusinessObject
        {
                public BOConfiguration() : base()
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
    <Hash>54f3722a51a068b0d91d864ccc66c7c7</Hash>
</Codenesium>*/