using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOProxy: AbstractBusinessObject
        {
                public BOProxy() : base()
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
    <Hash>cc64c6bde6ed52fcf88d03a031797d89</Hash>
</Codenesium>*/