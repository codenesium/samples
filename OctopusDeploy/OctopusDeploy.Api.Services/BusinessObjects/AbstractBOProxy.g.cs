using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOProxy : AbstractBusinessObject
        {
                public AbstractBOProxy()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>5d481853b2a631bd7a0dfc90d9ca5533</Hash>
</Codenesium>*/