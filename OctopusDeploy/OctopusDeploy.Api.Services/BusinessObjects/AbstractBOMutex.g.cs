using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOMutex: AbstractBusinessObject
        {
                public AbstractBOMutex() : base()
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
    <Hash>c00293c2a8d8d75d72615371666b5245</Hash>
</Codenesium>*/