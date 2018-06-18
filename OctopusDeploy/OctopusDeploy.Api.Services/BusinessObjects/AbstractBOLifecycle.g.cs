using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOLifecycle: AbstractBusinessObject
        {
                public AbstractBOLifecycle() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  byte[] dataVersion,
                                                  string jSON,
                                                  string name)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0b1bb0b4ab014933f3b7f992bec9c9ed</Hash>
</Codenesium>*/