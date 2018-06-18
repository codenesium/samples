using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOExtensionConfiguration: AbstractBusinessObject
        {
                public AbstractBOExtensionConfiguration() : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>f80d59ca32d997a059391cfcd7b770e2</Hash>
</Codenesium>*/