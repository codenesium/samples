using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOApiKey: AbstractBusinessObject
        {
                public BOApiKey() : base()
                {
                }

                public void SetProperties(string id,
                                          string apiKeyHashed,
                                          DateTime created,
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

                public DateTime Created { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a1e924f0d7d264cc61e57f968cd3f512</Hash>
</Codenesium>*/