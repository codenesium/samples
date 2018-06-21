using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOCommunityActionTemplate : AbstractBusinessObject
        {
                public AbstractBOCommunityActionTemplate()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  Guid externalId,
                                                  string jSON,
                                                  string name)
                {
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public Guid ExternalId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>33a76619936a076b0c3a350d5f51e8c9</Hash>
</Codenesium>*/