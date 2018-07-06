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

                public string DisplayName { get; private set; }

                public string EmailAddress { get; private set; }

                public string ExternalId { get; private set; }

                public string ExternalIdentifiers { get; private set; }

                public string Id { get; private set; }

                public Guid IdentificationToken { get; private set; }

                public bool IsActive { get; private set; }

                public bool IsService { get; private set; }

                public string JSON { get; private set; }

                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b76d77688a31a28479ee6fee3a22cdc7</Hash>
</Codenesium>*/