using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOMutex : AbstractBusinessObject
        {
                public AbstractBOMutex()
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
    <Hash>5f91a1bd0d435539baa0f201b28f298e</Hash>
</Codenesium>*/