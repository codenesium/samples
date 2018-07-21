using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiUserResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string displayName,
                        string emailAddress,
                        string externalId,
                        string externalIdentifiers,
                        Guid identificationToken,
                        bool isActive,
                        bool isService,
                        string jSON,
                        string username)
                {
                        this.Id = id;
                        this.DisplayName = displayName;
                        this.EmailAddress = emailAddress;
                        this.ExternalId = externalId;
                        this.ExternalIdentifiers = externalIdentifiers;
                        this.IdentificationToken = identificationToken;
                        this.IsActive = isActive;
                        this.IsService = isService;
                        this.JSON = jSON;
                        this.Username = username;
                }

                [Required]
                [JsonProperty]
                public string DisplayName { get; private set; }

                [Required]
                [JsonProperty]
                public string EmailAddress { get; private set; }

                [Required]
                [JsonProperty]
                public string ExternalId { get; private set; }

                [Required]
                [JsonProperty]
                public string ExternalIdentifiers { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public Guid IdentificationToken { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsActive { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsService { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a42cd714a83aaa5e6ca85a2ede2e50e1</Hash>
</Codenesium>*/