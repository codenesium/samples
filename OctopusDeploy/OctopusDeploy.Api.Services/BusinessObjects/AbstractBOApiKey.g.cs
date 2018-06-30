using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOApiKey : AbstractBusinessObject
        {
                public AbstractBOApiKey()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  string apiKeyHashed,
                                                  DateTimeOffset created,
                                                  string jSON,
                                                  string userId)
                {
                        this.ApiKeyHashed = apiKeyHashed;
                        this.Created = created;
                        this.Id = id;
                        this.JSON = jSON;
                        this.UserId = userId;
                }

                public string ApiKeyHashed { get; private set; }

                public DateTimeOffset Created { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d74e08a9eb79bf9c863fa6a53e75f7f1</Hash>
</Codenesium>*/