using Codenesium.DataConversionExtensions;
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
    <Hash>88e523e3f1b045d53230246d0c1ee5fc</Hash>
</Codenesium>*/