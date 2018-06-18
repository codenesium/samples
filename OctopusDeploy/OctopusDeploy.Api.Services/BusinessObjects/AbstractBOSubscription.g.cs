using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOSubscription: AbstractBusinessObject
        {
                public AbstractBOSubscription() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  bool isDisabled,
                                                  string jSON,
                                                  string name,
                                                  string type)
                {
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Type = type;
                }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>41ccee7e2fd2979a45df73b6e4b13c00</Hash>
</Codenesium>*/