using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOProxy: AbstractBusinessObject
        {
                public AbstractBOProxy() : base()
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
    <Hash>7b915ec00518b5e6d7de8ef78580586a</Hash>
</Codenesium>*/