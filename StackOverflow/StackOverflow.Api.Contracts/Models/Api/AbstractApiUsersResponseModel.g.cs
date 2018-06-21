using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiUsersResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string aboutMe,
                        Nullable<int> accountId,
                        Nullable<int> age,
                        DateTime creationDate,
                        string displayName,
                        int downVotes,
                        string emailHash,
                        int id,
                        DateTime lastAccessDate,
                        string location,
                        int reputation,
                        int upVotes,
                        int views,
                        string websiteUrl)
                {
                        this.AboutMe = aboutMe;
                        this.AccountId = accountId;
                        this.Age = age;
                        this.CreationDate = creationDate;
                        this.DisplayName = displayName;
                        this.DownVotes = downVotes;
                        this.EmailHash = emailHash;
                        this.Id = id;
                        this.LastAccessDate = lastAccessDate;
                        this.Location = location;
                        this.Reputation = reputation;
                        this.UpVotes = upVotes;
                        this.Views = views;
                        this.WebsiteUrl = websiteUrl;
                }

                public string AboutMe { get; private set; }

                public Nullable<int> AccountId { get; private set; }

                public Nullable<int> Age { get; private set; }

                public DateTime CreationDate { get; private set; }

                public string DisplayName { get; private set; }

                public int DownVotes { get; private set; }

                public string EmailHash { get; private set; }

                public int Id { get; private set; }

                public DateTime LastAccessDate { get; private set; }

                public string Location { get; private set; }

                public int Reputation { get; private set; }

                public int UpVotes { get; private set; }

                public int Views { get; private set; }

                public string WebsiteUrl { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAboutMeValue { get; set; } = true;

                public bool ShouldSerializeAboutMe()
                {
                        return this.ShouldSerializeAboutMeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeAccountIdValue { get; set; } = true;

                public bool ShouldSerializeAccountId()
                {
                        return this.ShouldSerializeAccountIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeAgeValue { get; set; } = true;

                public bool ShouldSerializeAge()
                {
                        return this.ShouldSerializeAgeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreationDateValue { get; set; } = true;

                public bool ShouldSerializeCreationDate()
                {
                        return this.ShouldSerializeCreationDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDisplayNameValue { get; set; } = true;

                public bool ShouldSerializeDisplayName()
                {
                        return this.ShouldSerializeDisplayNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDownVotesValue { get; set; } = true;

                public bool ShouldSerializeDownVotes()
                {
                        return this.ShouldSerializeDownVotesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailHashValue { get; set; } = true;

                public bool ShouldSerializeEmailHash()
                {
                        return this.ShouldSerializeEmailHashValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastAccessDateValue { get; set; } = true;

                public bool ShouldSerializeLastAccessDate()
                {
                        return this.ShouldSerializeLastAccessDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLocationValue { get; set; } = true;

                public bool ShouldSerializeLocation()
                {
                        return this.ShouldSerializeLocationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReputationValue { get; set; } = true;

                public bool ShouldSerializeReputation()
                {
                        return this.ShouldSerializeReputationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUpVotesValue { get; set; } = true;

                public bool ShouldSerializeUpVotes()
                {
                        return this.ShouldSerializeUpVotesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeViewsValue { get; set; } = true;

                public bool ShouldSerializeViews()
                {
                        return this.ShouldSerializeViewsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWebsiteUrlValue { get; set; } = true;

                public bool ShouldSerializeWebsiteUrl()
                {
                        return this.ShouldSerializeWebsiteUrlValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAboutMeValue = false;
                        this.ShouldSerializeAccountIdValue = false;
                        this.ShouldSerializeAgeValue = false;
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeDisplayNameValue = false;
                        this.ShouldSerializeDownVotesValue = false;
                        this.ShouldSerializeEmailHashValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastAccessDateValue = false;
                        this.ShouldSerializeLocationValue = false;
                        this.ShouldSerializeReputationValue = false;
                        this.ShouldSerializeUpVotesValue = false;
                        this.ShouldSerializeViewsValue = false;
                        this.ShouldSerializeWebsiteUrlValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>63e72c6424af813265c4f82b2a6e9f4c</Hash>
</Codenesium>*/