using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOConfiguration : AbstractBusinessObject
        {
                public AbstractBOConfiguration()
                        : base()
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
    <Hash>a5b319b8284332f5c3246b6b1147146a</Hash>
</Codenesium>*/