using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiUserResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string displayName,
                        string emailAddress,
                        string externalId,
                        string externalIdentifiers,
                        string id,
                        Guid identificationToken,
                        bool isActive,
                        bool isService,
                        string jSON,
                        string username)
                {
                        this.DisplayName = displayName;
                        this.EmailAddress = emailAddress;
                        this.ExternalId = externalId;
                        this.ExternalIdentifiers = externalIdentifiers;
                        this.Id = id;
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

                [JsonIgnore]
                public bool ShouldSerializeDisplayNameValue { get; set; } = true;

                public bool ShouldSerializeDisplayName()
                {
                        return this.ShouldSerializeDisplayNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailAddressValue { get; set; } = true;

                public bool ShouldSerializeEmailAddress()
                {
                        return this.ShouldSerializeEmailAddressValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdValue { get; set; } = true;

                public bool ShouldSerializeExternalId()
                {
                        return this.ShouldSerializeExternalIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdentifiersValue { get; set; } = true;

                public bool ShouldSerializeExternalIdentifiers()
                {
                        return this.ShouldSerializeExternalIdentifiersValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdentificationTokenValue { get; set; } = true;

                public bool ShouldSerializeIdentificationToken()
                {
                        return this.ShouldSerializeIdentificationTokenValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsActiveValue { get; set; } = true;

                public bool ShouldSerializeIsActive()
                {
                        return this.ShouldSerializeIsActiveValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsServiceValue { get; set; } = true;

                public bool ShouldSerializeIsService()
                {
                        return this.ShouldSerializeIsServiceValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUsernameValue { get; set; } = true;

                public bool ShouldSerializeUsername()
                {
                        return this.ShouldSerializeUsernameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDisplayNameValue = false;
                        this.ShouldSerializeEmailAddressValue = false;
                        this.ShouldSerializeExternalIdValue = false;
                        this.ShouldSerializeExternalIdentifiersValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIdentificationTokenValue = false;
                        this.ShouldSerializeIsActiveValue = false;
                        this.ShouldSerializeIsServiceValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeUsernameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ea21eedeb9951e295f1d9e378d2f258d</Hash>
</Codenesium>*/