using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOConfiguration: AbstractBusinessObject
        {
                public AbstractBOConfiguration() : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>f50c30e485bd50ec613150c4926ddafa</Hash>
</Codenesium>*/