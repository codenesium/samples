using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOExtensionConfiguration: AbstractBusinessObject
        {
                public BOExtensionConfiguration() : base()
                {
                }

                public void SetProperties(string id,
                                          string extensionAuthor,
                                          string jSON,
                                          string name)
                {
                        this.ExtensionAuthor = extensionAuthor;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string ExtensionAuthor { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f5313168981ee59dd2dde526c70aaa96</Hash>
</Codenesium>*/