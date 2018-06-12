using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOUserRole: AbstractBusinessObject
        {
                public BOUserRole() : base()
                {
                }

                public void SetProperties(string id,
                                          string jSON,
                                          string name)
                {
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7c4043ef755759b5029f4ed6e444e345</Hash>
</Codenesium>*/