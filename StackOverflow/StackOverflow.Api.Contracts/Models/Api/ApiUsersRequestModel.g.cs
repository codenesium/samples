using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiUsersRequestModel : AbstractApiRequestModel
        {
                public ApiUsersRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string aboutMe,
                        int? accountId,
                        int? age,
                        DateTime creationDate,
                        string displayName,
                        int downVotes,
                        string emailHash,
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
                        this.LastAccessDate = lastAccessDate;
                        this.Location = location;
                        this.Reputation = reputation;
                        this.UpVotes = upVotes;
                        this.Views = views;
                        this.WebsiteUrl = websiteUrl;
                }

                [JsonProperty]
                public string AboutMe { get; private set; }

                [JsonProperty]
                public int? AccountId { get; private set; }

                [JsonProperty]
                public int? Age { get; private set; }

                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [JsonProperty]
                public string DisplayName { get; private set; }

                [JsonProperty]
                public int DownVotes { get; private set; }

                [JsonProperty]
                public string EmailHash { get; private set; }

                [JsonProperty]
                public DateTime LastAccessDate { get; private set; }

                [JsonProperty]
                public string Location { get; private set; }

                [JsonProperty]
                public int Reputation { get; private set; }

                [JsonProperty]
                public int UpVotes { get; private set; }

                [JsonProperty]
                public int Views { get; private set; }

                [JsonProperty]
                public string WebsiteUrl { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8df5d5f24032c8cab81ab2b2fdf57d1c</Hash>
</Codenesium>*/