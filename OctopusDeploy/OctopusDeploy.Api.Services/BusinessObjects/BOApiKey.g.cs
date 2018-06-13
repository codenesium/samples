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
    <Hash>9eb2f5f64903bb3ac4ac70242cf04e5e</Hash>
</Codenesium>*/